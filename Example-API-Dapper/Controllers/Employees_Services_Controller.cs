using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Employees_Response_DTO;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Models_Request_DTO;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Services.Interfaces;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example_API_Dapper.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/employee_services")]
    public class Employees_ServicesController : ControllerBase
    {
        private readonly IEmployeeServices _employee_Services;
        
        private readonly ILogger _logger;

        public Employees_ServicesController(ILogger<CompaniesController> logger, IEmployeeServices employeeServices)
        {
            _logger = logger;
            _employee_Services = employeeServices;
        }

        /// <summary>
        /// Insert new employee using Services DTO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost(Name = "Insert Employee, using Services")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Get_Employee_Response_DTO>> Insert_Employee(Insert_Employees_Request_DTO entity)
        {
            try
            {
                return Ok(await _employee_Services.Insert_Employee(entity));
            }
            catch (Exception exception)
            {
                _logger.LogError($"The transaction failed. An error occurred in the {this.GetType().Name} model!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Get all Employees from the table using Services!
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "Get all employees using Services")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Get_Employee_Response_DTO>>> Get_all_Employees()
        {
            try
            {
                var result = _employee_Services.Get_all_Employees();
                _logger.LogInformation($"Received all events from the database! {this.GetType().Name} model!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"The transaction failed. An error occurred in the {this.GetType().Name} model!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }
    }
}
