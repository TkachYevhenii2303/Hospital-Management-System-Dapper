using System;
using System.Collections.Generic;
using System.Linq;
using Dapper_Data_Access_Layer.Context;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Microsoft.Data.SqlClient;

namespace Dapper_Data_Access_Layer.Repository.Contracts
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected DapperContext _context;
        protected SqlConnection _connection;
        private readonly string _table;
        public GenericRepository(DapperContext context, SqlConnection connection, string table)
        {
            _context = context;
            _connection = connection;
            _table = table;
        }
        public async Task<IEnumerable<T>> Get_Information()
        {
            string query = $"Select * From {_table}";
            using (var connection = _context.CreateConnection())
            {
                var information = await connection.
            }
        }
    }
}
