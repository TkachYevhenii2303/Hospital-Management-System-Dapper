using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Dapper_Example_Bussines_Logic.DTO.Services.Contaracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Example_Bussines_Logic.DTO.Services
{
    public class EmployeerManager : IEmployeerManager
    {
        private readonly IUnit_of_Work _Unit_of_Work;

        public EmployeerManager(IUnit_of_Work unit_of_Work)
        {
            _Unit_of_Work = unit_of_Work;
        }

        public async Task<IEnumerable<ResponseEmployeerInformation>> GetEmployeeByName(string employeerName)
        {
            var responseEmployee = new ResponseEmployeerInformation();
            var employeer = await _Unit_of_Work.EmployeesRepository.Get_By_Name(employeerName);

            responseEmployee.
        }
    }
}
