using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System_API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase   
    {
        private readonly IUnit_of_Work _Unit_of_Work;

        public EmployeesController(IUnit_of_Work unit_of_Work)
        {
            _Unit_of_Work = unit_of_Work;
        }

        [HttpGet, Route("Get_all_Employees")]
        public async Task<ActionResult<Result_Response<IEnumerable<Employees>>>> Get_all_Employees()
        {
            var result = await _Unit_of_Work.Employees_Repository.Get_all_Information();

            return Ok(result);  
        }
    }
}
