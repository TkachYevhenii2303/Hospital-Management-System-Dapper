using System.Data;
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

        public Unit_of_Work(IDbTransaction transaction, SqlConnection connection, ILogger logger)
        {
            _transaction = transaction;

            _connection = connection;
            
            _logger = logger;
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
