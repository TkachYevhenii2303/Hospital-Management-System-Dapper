using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Example_API_Dapper.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        public CompaniesController(ICompanyRepository companyRepository) => _companyRepository = companyRepository;

        /// <summary>
        /// Returns the list of Companies 
        /// </summary>
        /// <returns>The list of Companies</returns>
        /// <remarks>Simple Request - Get: /api/companies</remarks>
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _companyRepository.GetCompanies();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Return the company by ID
        /// </summary>
        /// <param name="id">Parameter for the Request</param>
        /// <returns>The company by id</returns>
        /// <remarks>The Request with the parameter</remarks>
        [HttpGet("{id}", Name = "Company-By-Id")]
        public async Task<IActionResult> GetCompany(int id)
        {
            try
            {
                var company = await _companyRepository.GetCompany(id);
                if (company.Equals(null)) return NotFound();
                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
