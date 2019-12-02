using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ISchoolRepository
    {
        Task<School> GetById(string id);

        Task<IEnumerable<School>> GetAll();
    }
}