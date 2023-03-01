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
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IUnit_of_Work _unit_of_Work;
        private readonly Logger<CompaniesController> _logger;
        public EmployeesController(IEmployeesRepository employeesRepository, Logger<CompaniesController> logger, IUnit_of_Work unitOfWork)
        {
            _employeesRepository = employeesRepository;
            _logger = logger;
            _unit_of_Work = unitOfWork;
        }
    }
}
