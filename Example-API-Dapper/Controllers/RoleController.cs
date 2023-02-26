using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Repository.Contracts;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Example_API_Dapper.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _RoleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _RoleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get_all_Information()
        {
            try
            {
                var departments = await _RoleRepository.Get_all_Information();
                return Ok(departments);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
