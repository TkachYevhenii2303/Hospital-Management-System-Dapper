using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Example_API_Dapper.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase 
    {
        private readonly IEmployeesRepository _employeesRepository;
        public EmployeesController(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        /// <summary>
        /// Get_all_Employees_By_Specialization
        /// </summary>
        /// <param name="specialization"></param>
        /// <returns></returns>
        [HttpGet("{Specialization}", Name = "Specialization_Employees")]
        public async Task<IActionResult> Get_all_Employees_By_Specialization(string specialization)
        {
            try
            {
                var employees = await _employeesRepository.Get_all_Employees_By_Specialization(specialization);
                return Ok(employees);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Get_all_activity_Employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get_all_activity_Employees()
        {
            try
            {
                var employees = await _employeesRepository.Get_all_activity_Employees();
                return Ok(employees);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
