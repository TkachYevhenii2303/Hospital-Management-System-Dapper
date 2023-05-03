using Dapper_Data_Access_Layer.Entities;
using Dapper_Example_Bussines_Logic.Data_trasfer_objects.Request_Result_DTO;
using Dapper_Example_Bussines_Logic.Data_trasfer_objects.Response_Result_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Example_Bussines_Logic.Data_trasfer_objects.Services.Interfaces
{
    public interface IEmployees_Services
    {
        public Task<Result_Response<IEnumerable<Employees_Response_DTO>>> Get_all_Employees();

        public Task<Result_Response<Employees_Response_DTO>> Get_Employee_ID(Guid ID);

        public Task<Result_Response<IEnumerable<Employees_Response_DTO>>> Insert_Employee(Employees_Request_DTO Employee);

        public Task<Result_Response<IEnumerable<Employees_Response_DTO>>> Update_Employee(Employees_Request_Update_DTO Employee);

        public Task<Result_Response<IEnumerable<Employees_Response_DTO>>> Delete_Employee(Guid ID);

        public Task<Result_Response<IEnumerable<Employees_Departments_Result_DTO>>> Get_Employees_and_Departments_ID(Guid ID);

        public Task<IEnumerable<String>> Get_all_Departments_titles_ID(Guid ID);
    }
}
