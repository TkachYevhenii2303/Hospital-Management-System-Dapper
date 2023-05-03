using Dapper_Data_Access_Layer.Data_transfer_objects_on_DAL.Response_Result_DTO;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Dapper_Example_Bussines_Logic.Data_trasfer_objects.Request_Result_DTO;
using Dapper_Example_Bussines_Logic.Data_trasfer_objects.Response_Result_DTO;
using Dapper_Example_Bussines_Logic.Data_trasfer_objects.Services;
using Dapper_Example_Bussines_Logic.Data_trasfer_objects.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System_API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase   
    {
        private readonly IEmployees_Services _Employees_Services;

        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(IEmployees_Services employees_Services, ILogger<EmployeesController> logger)
        {
            _Employees_Services = employees_Services;
            _logger = logger;
        }

        /// <summary>
        /// Fetching all information from Employees table 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("Get_all_Employees")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Result_Response<IEnumerable<Employees_Response_DTO>>>> Get_all_Employees()
        {
            try
            {
                _logger.LogInformation("Fetching all information from Employees table...");

                var result = await _Employees_Services.Get_all_Employees();
                
                _logger.LogInformation("Everything is good! Operations is Succesfull!");

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Something went wrong in {Get_all_Employees().GetType().Name} method!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Fetching the Employee with by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet, Route("Get_Employees_ID/{ID}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Result_Response<Employees_Response_DTO>>> Get_Employees_ID(Guid ID)
        {
            try
            {
                _logger.LogInformation($"Fetching the Employee with {ID} ID...");
                var result = await _Employees_Services.Get_Employee_ID(ID);

                if (result is null) 
                {
                    _logger.LogInformation($"The Entity with {ID} ID was not found in table Employees!!!");
                    return StatusCode(StatusCodes.Status404NotFound); 
                }

                _logger.LogInformation("Everything is good! Operations is Succesfull!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Something went wrong in {Get_Employees_ID(ID).GetType().Name} method!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Inserting the Employee to the table
        /// </summary>
        /// <param name="Employees"></param>
        /// <returns></returns>
        [HttpPost, Route("Insert_Employees/Employees")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Result_Response<IEnumerable<Employees_Response_DTO>>>> Insert_Employees([FromBody] Employees_Request_DTO Employees)
        {
            try
            {
                _logger.LogInformation($"Inserting the Employee to the table...");
                var result = await _Employees_Services.Insert_Employee(Employees);

                _logger.LogInformation("Everything is good! Operations is Succesfull!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Something went wrong in {Insert_Employees(Employees).GetType().Name} method!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Updating the Employee to the table
        /// </summary>
        /// <param name="Employees"></param>
        /// <returns></returns>
        [HttpPut, Route("Update_Employees/Employees")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Result_Response<IEnumerable<Employees_Response_DTO>>>> Update_Employees([FromBody] Employees_Request_Update_DTO Employees)
        {
            try
            {
                _logger.LogInformation($"Updating the Employee to the table...");
                var result = await _Employees_Services.Update_Employee(Employees);

                _logger.LogInformation("Everything is good! Operations is Succesfull!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Something went wrong in {Update_Employees(Employees).GetType().Name} method!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Deleting the Employee to the table
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete, Route("Delete_Employees/{ID}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Result_Response<IEnumerable<Employees_Response_DTO>>>> Delete_Employees(Guid ID)
        {
            try
            {
                _logger.LogInformation($"Deleting the Employee to the table...");
                var result = await _Employees_Services.Delete_Employee(ID);

                _logger.LogInformation("Everything is good! Operations is Succesfull!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Something went wrong in {Delete_Employees(ID).GetType().Name} method!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Fetching the Get_Employees_and_Departments_ID with ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet, Route("Get_Employees_and_Departments_ID/{ID}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Result_Response<Employees>>> Get_Employees_and_Departments_ID(Guid ID)
        {
            try
            {
                _logger.LogInformation($"Fetching the Get_Employees_and_Departments_ID with {ID} ID...");
                var result = await _Employees_Services.Get_Employees_and_Departments_ID(ID);

                if (result is null)
                {
                    _logger.LogInformation($"The Entity with {ID} ID was not found in table Employees!!!");
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                _logger.LogInformation("Everything is good! Operations is Succesfull!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Something went wrong in {Get_Employees_and_Departments_ID(ID).GetType().Name} method!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Fetching the Departments titles by ID for the Employee
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet, Route("Get_Departments_titles_ID/{ID}")]
        public async Task<ActionResult<IEnumerable<string>>> Get_Departments_titles_ID(Guid ID)
        {
            try
            {
                _logger.LogInformation($"Fetching the Get_Employees_and_Departments_ID with {ID} ID...");
                var result = await _Employees_Services.Get_all_Departments_titles_ID(ID);

                if (result is null)
                {
                    _logger.LogInformation($"The Entity with {ID} ID was not found in table Employees!!!");
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                _logger.LogInformation("Everything is good! Operations is Succesfull!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Something went wrong in {Get_Departments_titles_ID(ID).GetType().Name} method!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
