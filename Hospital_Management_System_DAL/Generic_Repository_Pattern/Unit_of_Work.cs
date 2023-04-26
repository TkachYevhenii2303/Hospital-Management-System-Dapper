using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern
{
    public class Unit_of_Work : IUnit_of_Work
    {
        private readonly IDbTransaction _transaction;

        private readonly SqlConnection _connection;

        private readonly ILogger _logger;

        public ICompany_Repository Company_Repository { get; }
        
        public IEmployees_Repository Employees_Repository { get; }
        
        public IDepartment_Repository Department_Repository { get; }

        public Unit_of_Work(IDbTransaction transaction, SqlConnection connection, ILogger logger, 
            ICompany_Repository companyRepository, 
            IEmployees_Repository employeesRepository,
            IDepartment_Repository departmentRepository)
        {
            _transaction = transaction;

            _connection = connection;
            
            _logger = logger;

            Company_Repository = companyRepository;

            Employees_Repository = employeesRepository;

            Department_Repository = departmentRepository;
        }

        public void Dispose()
        {
            _transaction.Connection?.Close();
            _transaction.Connection?.Dispose();
            _transaction.Dispose();
        }

        public void Complete()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception exception)
            {
                _transaction.Rollback(); _logger.LogError($"Something went wrong in Unit of Work Pattern! {exception.Message}");
            }
        }
    }
}
