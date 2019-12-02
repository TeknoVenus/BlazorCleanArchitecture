using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Data.TypedHttpClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    /// <summary>
    /// Implementation of ISchoolRepository to pull school information from Wonde
    /// </summary>
    public class SchoolRepository : ISchoolRepository
    {
        private readonly HttpClient _httpClient;

        public SchoolRepository(WondeClient httpClient)
        {
            _httpClient = httpClient.Client;
        }

        /// <summary>
        /// Get a specific school by Wonde ID
        /// </summary>
        /// <param name="id">Wonde ID of the school to find</param>
        /// <returns></returns>
        public async Task<School> GetById(string id)
        {
            var url = $"/schools/{id}";
            var response = await _httpClient.GetStringAsync(url).ConfigureAwait(false);

            // TODO:: Further validation of Http response should be handled by Polly for circuit-breaker logic
            if (string.IsNullOrWhiteSpace(response))
            {
                return null;
            }

            var school = JsonConvert.DeserializeObject<WondeItem<School>>(response);
            return school.Data;
        }

        /// <summary>
        /// Gets all the schools known in Wonde
        /// </summary>
        /// <remarks>Note if you have a single-school token you will only get the school that token allows access to</remarks>
        /// <param name="perPage"></param>
        /// <param name="currentPage"></param>
        /// <returns></returns>
        public async Task<IEnumerable<School>> GetAll()
        {
            const int perPage = 200;
            var currentPage = 1;
            var lastPage = false;

            var schoolList = new List<School>();

            // Wonde returns a paginated API, so loop through and get all data (quick and dirty method)
            // TOOD:: Would make sense to refactor this into a method that can be re-used to fetch all pages
            do
            {
                var url = $"schools?per_page={perPage}&page={currentPage}";
                var response = await _httpClient.GetStringAsync(url).ConfigureAwait(false);

                if (string.IsNullOrWhiteSpace(response))
                {
                    return null;
                }

                var schools = JsonConvert.DeserializeObject<WondeCollection<School>>(response);

                schoolList.AddRange(schools.Data);
                if (schools.Meta.Pagination.More)
                {
                    currentPage++;
                }
                else
                {
                    lastPage = true;
                }
            } while (!lastPage);

            return schoolList;
        }
    }
}