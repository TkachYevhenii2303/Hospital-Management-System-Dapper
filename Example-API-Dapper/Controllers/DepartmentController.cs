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
        private IDepartmentRepository _DepartmentRepository;
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

        [HttpGet("Department-By-Id")]
        public async Task<IActionResult> Get_by_Id(int id)
        {
            try
            {
                var departmetn = await _DepartmentRepository.Get_by_Id(id);
                return Ok(departmetn);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

    }
}
