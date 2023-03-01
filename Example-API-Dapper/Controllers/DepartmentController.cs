using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Example_API_Dapper.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnit_of_Work _unit_of_Work;
        private readonly Logger<CompaniesController> _logger;
        public DepartmentController(IDepartmentRepository departmentRepository, IUnit_of_Work unitOfWork, Logger<CompaniesController> logger)
        {
            _departmentRepository = departmentRepository;
            _unit_of_Work = unitOfWork;
            _logger = logger;
        }
    }
}
