using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Employees_Response_DTO;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Example_Bussines_Logic.Data_Transfer_Object.Services.Models
{
    public class EmployeeServices : IEmployeeServices
    {
        public async Task<Services_Response<IEnumerable<Get_Employee_Response_DTO>>> Get_all_Employees()
        {
            
        }
    }
}
