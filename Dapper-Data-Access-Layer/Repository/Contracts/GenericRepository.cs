using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Dapper_Data_Access_Layer.Context;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
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

        public async Task<T> Get_ID(int id)
        {
            var result = await _connection.QuerySingleOrDefaultAsync<T>($"Select * From {table} Where Id = @Id",
                param: new { Id = id },
                transaction: _transaction);

            if (Equals(result, null))
            {
                throw new KeyNotFoundException($"{table} with ID: {id} could not be found!");
            }

            return result;
        }

        public async Task Delete_ID(int id)
        {
            await _connection.ExecuteAsync($"Delete From {table} Where Id = @Id",
                param: new { Id = id },
                transaction: _transaction);
        }

        public async Task<int> Add_Range(IEnumerable<T> List)
        {
            var Inserted = 0;
            var query = GenerateInsertQuery();
            Inserted += await _connection.ExecuteAsync(query, param: List);
            return Inserted;
        }

        public Task Replace(T element)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Add_Element(T element)
        {
            var Inserted = GenerateInsertQuery();
            var new_ID = await _connection.ExecuteScalarAsync<int>(Inserted, param: element,
                transaction: _transaction);
            return new_ID;
        }

        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();

        private static List<string> GenerateListProperties(IEnumerable<PropertyInfo> ListProperty)
        {
            return (from Property in ListProperty
                let attributes = Property.GetCustomAttributes(typeof(DescriptionAttribute), false)
                where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                select Property.Name).ToList();
        }
        private string GenerateInsertQuery()
        {
            var InsertQuery = new StringBuilder($"Insert into {table} ");
            InsertQuery.Append("(");
            var Properties = GenerateListProperties(GetProperties);
            Properties.Remove("Id");

            Properties.ForEach(Prop => { InsertQuery.Append($"[{Prop}], ");});
            InsertQuery
                .Remove(InsertQuery.Length -1, 1)
                .Append(") Values (");

            Properties.ForEach(Prop => { InsertQuery.Append($"@{Prop}");});
            InsertQuery
                .Remove(InsertQuery.Length - 1, 1)
                .Append(")");

            InsertQuery.Append($"; Select Scope_Identity()");
            return InsertQuery.ToString();
        }

        private string GenerateUpdateQuery()
        {
            var Updated = new StringBuilder($"Update {table} Set ");
            var Properties = GenerateListProperties(GetProperties);

            Properties.ForEach(Property =>
                {
                    if (!Property.Equals("Id"))
                    {
                        Updated.Append($"{Property} = @{Property}, ");
                    }
                });

            Updated.Remove(Updated.Length - 1, 1);
            Updated.Append(" Where Id = @Id");
            return Updated.ToString();
        }
    }
}
