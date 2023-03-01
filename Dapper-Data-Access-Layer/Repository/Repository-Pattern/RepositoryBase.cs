using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper_Data_Access_Layer.Base_Entity;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Microsoft.Data.SqlClient;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern
{
    public class RepositoryBase<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        protected IDbConnection _connection;
        protected IDbTransaction _transaction;
        protected string _table;

        public RepositoryBase(IDbConnection connection, IDbTransaction transaction, string table)
        {
            _connection = connection;
            _transaction = transaction;
            _table = table;
        }

        public async Task<IEnumerable<TEntity>> Get_all_Information()
        {
            var query = $"Select * From {_table}";
            return await _connection.QueryAsync<TEntity>(query, transaction: _transaction);
        }

        public async Task<TEntity> Get_by_Id(int id)
        {
            string query = $"Select * From {_table} Where Id = @id";
            var result =
                await _connection.QueryFirstOrDefaultAsync<TEntity>(query, param: new { id }, transaction: _transaction);

            if (result == null)
            {
                throw new KeyNotFoundException($"{_table} with id [{id}] could not be found.");
            }

            return result;
        }

        public Task Insert_Entity(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Update_Entity(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete_Entity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
