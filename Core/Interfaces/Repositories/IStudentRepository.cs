using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetById(string schoolId, string studentId);

        Task<IEnumerable<Student>> GetAll(string schoolId);
    }
}