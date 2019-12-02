using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Data.TypedHttpClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly HttpClient _httpClient;

        public StudentRepository(WondeClient httpClient)
        {
            _httpClient = httpClient.Client;
        }

        /// <summary>
        /// Gets all students in a given school
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Student>> GetAll(string schoolId)
        {
            const int perPage = 200;
            var currentPage = 1;
            var lastPage = false;

            var studentList = new List<Student>();

            // Wonde returns a paginated API, so loop through and get all data (quick and dirty method)
            // TOOD:: Would make sense to refactor this into a method that can be re-used to fetch all pages
            do
            {
                var url = $"schools/{schoolId}/students/?per_page={perPage}&page={currentPage}";
                var response = await _httpClient.GetStringAsync(url).ConfigureAwait(false);

                if (string.IsNullOrWhiteSpace(response))
                {
                    return null;
                }

                var students = JsonConvert.DeserializeObject<WondeCollection<Student>>(response);

                studentList.AddRange(students.Data);
                if (students.Meta.Pagination.More)
                {
                    currentPage++;
                }
                else
                {
                    lastPage = true;
                }
            } while (!lastPage);

            return studentList;
        }

        /// <summary>
        /// Gets a specific student from a school
        /// </summary>
        /// <param name="schoolId">ID of the school the student is enrolled in</param>
        /// <param name="studentId">ID of the student in the school</param>
        /// <returns></returns>
        public async Task<Student> GetById(string schoolId, string studentId)
        {
            var url = $"schools/{schoolId}/students/{studentId}";

            var response = await _httpClient.GetStringAsync(url).ConfigureAwait(false);

            // TODO:: Polly will handle HTTP errors
            if (string.IsNullOrWhiteSpace(response))
            {
                return null;
            }

            var student = JsonConvert.DeserializeObject<WondeItem<Student>>(response);
            return student.Data;
        }
    }
}