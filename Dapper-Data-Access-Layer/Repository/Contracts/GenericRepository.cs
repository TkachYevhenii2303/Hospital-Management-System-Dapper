using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper_Data_Access_Layer.Context;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using Dapper;


namespace Dapper_Data_Access_Layer.Repository.Contracts
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected DapperContext _context;
        protected SqlConnection _connection;
        protected IDbTransaction _transaction;
        private readonly string table;
        protected GenericRepository(SqlConnection connection, string table, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
            this.table = table;
        }
        public async Task<IEnumerable<T>> Get_Information()
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<T>($"Select * From {table}", 
                    transaction: _transaction);
            }
        }
    }
}
