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
        protected SqlConnection _connection;
        protected IDbTransaction _transaction;
        protected string title_table;

        public RepositoryBase(SqlConnection connection, IDbTransaction transaction, string titleTable)
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
    }
}
