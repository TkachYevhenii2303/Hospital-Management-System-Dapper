using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;

namespace Dapper_Data_Access_Layer.Repository.Contracts.Interfaces
{
    public interface IEmployeesRepository : IGenericRepository<Employees>
    {
        public Task<Services_Repsponse<IEnumerable<Employees>>> Get_all_activity_Employees();
    }
}
