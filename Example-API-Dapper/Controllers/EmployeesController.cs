using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.Contracts;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Example_API_Dapper.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnit_of_Work _unit_of_Work;
        private readonly ILogger _logger;
        public EmployeesController(IEmployeesRepository employeesRepository, ILogger<CompaniesController> logger, IUnit_of_Work unitOfWork)
        {
            _logger = logger;
            _unit_of_Work = unitOfWork;
        }

        /// <summary>
        /// Get all information about employees in database
        /// </summary>
        /// <returns>The list of all employees in database</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> Get_all_Information()
        {
            try
            {
                IEnumerable<Employees> result = await _unit_of_Work.EmployeesRepository.Get_all_Information();
                _unit_of_Work.Commit();
                _logger.LogInformation($"Received all events from the database! {this.GetType().Name} model!");
                return Ok(result);

            }
            catch (Exception exception)
            {
                _logger.LogError($"The transaction failed. An error occurred in the {this.GetType().Name} model!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

        /// <summary>
        /// Get the concrete employee by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee object</returns>
        [HttpGet("Id")]
        public async Task<IActionResult> Get_by_Id(int id)
        {
            try
            {
                var result = await _unit_of_Work.EmployeesRepository.Get_by_Id(id);
                _unit_of_Work.Commit();

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
        public async Task<IActionResult> Insert_Entity(Employees entity)
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

                await _unit_of_Work.EmployeesRepository.Insert_Entity(entity);
                _unit_of_Work.Commit();

                return StatusCode(StatusCodes.Status201Created);
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
        public async Task<IActionResult> Delete_Entity(int id)
        {
            try
            {
                var result = await _unit_of_Work.EmployeesRepository.Get_by_Id(id);
                if (result == null)
                {
                    _logger.LogInformation($"The model with Id: {id} was not found in the database!");
                    return NotFound();
                }

                await _unit_of_Work.EmployeesRepository.Delete_Entity(id);
                _unit_of_Work.Commit();
                return StatusCode(StatusCodes.Status204NoContent);
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
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("Id")]
        public async Task<IActionResult> Update_Entity(int id, Employees entity)
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

                var result = await _unit_of_Work.EmployeesRepository.Get_by_Id(id);

                if (result == null)
                {
                    _logger.LogInformation($"The model with Id: {id} was not found in the database!");
                    return NotFound();
                }

                await _unit_of_Work.EmployeesRepository.Update_Entity(entity);
                _unit_of_Work.Commit();
                return StatusCode(StatusCodes.Status204NoContent);

            }
            catch (Exception exception)
            {
                _logger.LogError($"The transaction failed. An error occurred in the {this.GetType().Name} model!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }


        [HttpGet("First_name")]
        public async Task<IActionResult> Get_Employee_By_Name(string name)
        {
            try
            {

            }
            catch (Exception exception)
            {

            }
        }

    }
}
