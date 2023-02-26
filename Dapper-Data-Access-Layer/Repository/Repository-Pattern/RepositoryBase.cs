using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper_Data_Access_Layer.Context;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Microsoft.Data.SqlClient;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IDbConnection _connection;
        protected IDbTransaction _transaction;
        protected string title_table;

        public RepositoryBase(IDbConnection connection, IDbTransaction transaction, string titleTable)
        {
            _connection = connection;
            _transaction = transaction;
            title_table = titleTable;
        }

        public async Task<IEnumerable<TEntity>> Get_all_Information()
        {
            var query = $"Select * From {title_table}";
            return await _connection.QueryAsync<TEntity>(query, transaction: _transaction);
        }

        public async Task<TEntity> Get_by_Id(int id)
        {
            string query = $"Select * From {title_table} Where Id = @id";
            var result =
                await _connection.QueryFirstOrDefaultAsync<TEntity>(query, param: new { id }, transaction: _transaction);

            if (result == null)
            {
                throw new KeyNotFoundException($"{title_table} with id [{id}] could not be found.");
            }

            return result;
        }
    }
}
