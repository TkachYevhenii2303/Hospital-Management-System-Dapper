﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Dapper_Example_Bussines_Logic.Dto;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Example_API_Dapper.Controllers
{
    [ApiController]
    [Route("api/companies")]
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
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
                if (company == null)
                {
                    return NotFound();
                }
                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Created the new Company for the Database
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyForCreationDto company)
        {
            try
            {
                var createdCompany = await _companyRepository.CreateCompany(company);
                return CreatedAtRoute("Company-By-Id", new { id = createdCompany.Id }, createdCompany);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Update the concrete Clinic by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, CompanyForCreationDto company)
        {
            try
            {
                var dbCompany = await _companyRepository.GetCompany(id);
                if (dbCompany == null)
                {
                    return NotFound();
                }

                await _companyRepository.UpdateCompany(id, company);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Delete some clinic by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                var dbCompany = await _companyRepository.GetCompany(id);
                if (dbCompany == null)
                {
                    return NotFound();
                }

                await _companyRepository.DeleteCompany(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Find Clinic by Department ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Department/{id}")]
        public async Task<IActionResult> CompanyDepartmentId(int id)
        {
            try
            {
                var companies = await _companyRepository.CompanyDepartmentId(id);
                if (companies == null)
                {
                    return NotFound();
                }

                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Get all clinic with Department using Multi Mapping
        /// </summary>
        /// <returns></returns>
        [HttpGet("MultiMapping")]
        public async Task<IActionResult> GetCompaniesMultiMapping()
        {
            try
            {
                var company = await _companyRepository.GetCompaniesMultiMapping();
                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("Multiple")]
        public async Task<IActionResult> CreateCompany(List<CompanyForCreationDto> companies)
        {
            try
            {
                await _companyRepository.CreateMultipleCompanies(companies);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}