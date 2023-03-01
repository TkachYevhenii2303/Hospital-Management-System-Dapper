using System;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clinic>>> Get_all_Information()
        {
            try
            {
                IEnumerable<Clinic> result = await _unit_of_Work.CompanyRepository.Get_all_Information();
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
    }
}
