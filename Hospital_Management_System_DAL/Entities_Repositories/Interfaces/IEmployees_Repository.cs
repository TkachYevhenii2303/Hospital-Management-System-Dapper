using Dapper_Data_Access_Layer.Data_transfer_objects_on_DAL.Response_Result_DTO;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities_Repositories.Interfaces
{
    public interface IEmployees_Repository : IGenericRepository<Employees>
    {
        public Task<Result_Response<Employees>> Get_Employees_and_Departments(Guid ID);

        public Task<IEnumerable<string>> Get_Departments_title_ID(Guid ID);
    }
}
