﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Example_API_Dapper.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly IUnit_of_Work _unit_of_Work;
        private readonly ILogger _logger;
        public CompaniesController(IUnit_of_Work unitOfWork, ILogger<CompaniesController> logger)
        {
            _unit_of_Work = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Get all information about clinics in database
        /// </summary>
        /// <returns>The list of all clinic in database</returns>
        [HttpGet(Name = "Get all information about companies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Clinic>>> Get_all_Information()
        {
            try
            {
                var result = await _unit_of_Work.CompanyRepository.Get_all_Information();
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
        /// Get the concrete clinic by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Clinic object</returns>
        [HttpGet("Id", Name = "Get concrete company by ID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Clinic>> Get_by_Id(Guid id)
        {
            try
            {
                var result = await _unit_of_Work.CompanyRepository.Get_by_Id(id);
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
        /// Method for the Insert new Entity to the Clinic List
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Insert_Entity(Clinic entity)
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

                await _unit_of_Work.CompanyRepository.Insert_Entity(entity);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete_Entity(Guid id)
        {
            try
            {
                var result = await _unit_of_Work.CompanyRepository.Get_by_Id(id);
                if (result == null)
                {
                    _logger.LogInformation($"The model with Id: {id} was not found in the database!");
                    return NotFound();
                }

                await _unit_of_Work.CompanyRepository.Delete_Entity(id);
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update_Entity(Guid id, Clinic entity)
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

                var result = await _unit_of_Work.CompanyRepository.Get_by_Id(id);
                
                if (result == null)
                {
                    _logger.LogInformation($"The model with Id: {id} was not found in the database!");
                    return NotFound();
                }

                await _unit_of_Work.CompanyRepository.Update_Entity(entity);
                _unit_of_Work.Commit();
                return StatusCode(StatusCodes.Status204NoContent);

            }
            catch (Exception exception)
            {
                _logger.LogError($"The transaction failed. An error occurred in the {this.GetType().Name} model!");
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
