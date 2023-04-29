using System.Data;
using Dapper_Data_Access_Layer.Entities_Repositories;
using Dapper_Data_Access_Layer.Entities_Repositories.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern
{
    public class Unit_of_Work : IUnit_of_Work
    {
        private readonly IDbTransaction _transaction;

        private readonly SqlConnection _connection;

        private readonly ILogger<Unit_of_Work> _logger;

        public IEmployees_Repository Employees_Repository { get; set; }
        
        public Unit_of_Work(IDbTransaction transaction, SqlConnection connection, ILogger<Unit_of_Work> logger)
        {
            _transaction = transaction;

            _connection = connection;
            
            _logger = logger;

            Employees_Repository = new Employees_Repository(_connection, _transaction);
        }

        public void Dispose() => _transaction.Dispose();

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
