using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Employees_Response_DTO;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Models_Request_DTO;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Models_Request_DTO.Employees_Services_DTO;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dapper_Example_Bussines_Logic.Data_Transfer_Object.Services.Interfaces
{
    public interface IEmployeeServices
    {
        public Task<IEnumerable<Get_Employee_Response_DTO>>
            Insert_Employee(Insert_Employees_Request_DTO entity);

        public Task<IEnumerable<Get_Employee_Response_DTO>> Get_all_Employees();

        public Task<Get_Employee_Response_DTO> Get_Employee_ID(Guid Id);

        public Task<IEnumerable<Get_Employee_Response_DTO>> Update_Employee(Update_Employees_Request_DTO entity);

        public Task<IEnumerable<Get_Employee_Response_DTO>> Delete_Employees(Guid Id);
    }
}
