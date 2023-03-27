using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Employees_Response_DTO;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Models_Request_DTO;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Services.Interfaces;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Services.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Example_API_Dapper.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServices _employee_Services;
        private readonly ILogger _logger;

        public EmployeesController(ILogger<CompaniesController> logger, IEmployeeServices employee_Services)
        {
            _logger = logger;
            _employee_Services = employee_Services;
        }

        /// <summary>
        /// Get all information about employees in database using services
        /// </summary>
        /// <returns>The list of all employees in database</returns>
        [HttpGet(Name = "Get_information_Employees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Get_Employee_Response_DTO>>> Get_all_Information()
        {
            try
            {
                var result = await _employee_Services.Get_all_Employees();
                _logger.LogInformation($"Received all events from the database! {this.GetType().Name} model!");
                return Ok(result);

            }
            catch (Exception exception)
            {
                _logger.LogError($"The transaction failed. An error occurred in the {this.GetType().Name} model!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

       /* /// <summary>
        /// Get the concrete employee by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee object</returns>
        [HttpGet("Id", Name = "Get_Employee_ID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Get_Employee_Response_DTO>> Get_by_Id(Guid id)
        {
            try
            {
                var result = await _employee_Services.Get_Employee_ID(id);

                if (result == null)
                {
                    _logger.LogInformation($"The model with Id: {id} was not found in the database!");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Received an event from the database!");
                    return Ok(result);
                }
            }
            catch (Exception exception)
            {
                _logger.LogError($"The transaction failed. An error occurred in the {this.GetType().Name} model!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

        /// <summary>
        /// Method for the Insert new Entity to the Employee List
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Get_Employee_Response_DTO>>> Insert_Entity(Insert_Employees_Request_DTO entity)
        {
            try
            {
                if (entity == null)
                {
                    _logger.LogInformation($"We got empty json from client side");
                    return BadRequest($"The event object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"We received incorrect json from the client side");
                    return BadRequest("The event object is invalid");
                }

                var result = await _employee_Services.Insert_Employee(entity);
                return Ok(result);
                
            }
            catch (Exception exception)
            {
                _logger.LogError($"The transaction failed. An error occurred in the {this.GetType().Name} model!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Method for the Deleting the entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Get_Employee_Response_DTO>>> Delete_Entity(Guid id)
        {
            try
            {
                var entity = await _employee_Services.Get_Employee_ID(id);
                if (entity == null)
                {
                    _logger.LogInformation($"The model with Id: {id} was not found in the database!");
                    return NotFound();
                }

                var result = await _employee_Services.Delete_Employees(id);

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"The transaction failed. An error occurred in the {this.GetType().Name} model!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Method for updating some entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Get_Employee_Response_DTO>>> Update_Entity(Update_Employees_Request_DTO entity)
        {
            try
            {
                if (entity == null)
                {
                    _logger.LogInformation($"We got empty json from client side");
                    return BadRequest($"The event object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"We received incorrect json from the client side");
                    return BadRequest("The event object is invalid");
                }

                var result = await _employee_Services.Get_Employee_ID(entity.Id);

                if (result == null)
                {
                    _logger.LogInformation($"The model with Id: {entity.Id} was not found in the database!");
                    return NotFound();
                }

                return Ok(await _employee_Services.Update_Employee(entity));
            }
            catch (Exception exception)
            {
                _logger.LogError($"The transaction failed. An error occurred in the {this.GetType().Name} model!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }*/
    }
}
