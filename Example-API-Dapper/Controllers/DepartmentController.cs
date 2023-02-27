using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Example_API_Dapper.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _DepartmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository) => _DepartmentRepository = departmentRepository;

        /// <summary>
        /// Get all Information about Departments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get_all_Information()
        {
            try
            {
                var departments = await _DepartmentRepository.Get_all_Information();
                return Ok(departments);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpGet("Top_Five")]
        public async Task<IActionResult> Get_five_Departments()
        {
            try
            {
                var departments = await _DepartmentRepository.Get_five_Departments();
                return Ok(departments);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet("{id}", Name = "Department-ID")]
        public async Task<IActionResult> Get_by_Id(int id)
        {
            try
            {
                var department = await _DepartmentRepository.Get_by_Id(id);
                if (department == null)
                {
                    return NotFound();
                }
                return Ok(department);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpDelete("{id}", Name = "Department_ID")]
        public async Task<IActionResult> Delete_Department(int id)
        {
            try
            {
                var department = await _DepartmentRepository.Get_by_Id(id);
                if (department == null)
                {
                    return NotFound();
                }

                await _DepartmentRepository.Delete_Entity(id);

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

    }
}
