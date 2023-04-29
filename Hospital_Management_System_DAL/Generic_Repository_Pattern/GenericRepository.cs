using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper_Data_Access_Layer.Base_Entity;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Microsoft.Data.SqlClient;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> 
        where TEntity : Entity
    {
        protected readonly SqlConnection _connection;

        protected readonly IDbTransaction _transaction;
        
        protected readonly string _table;

        public GenericRepository(SqlConnection connection, IDbTransaction transaction, string table)
        {
            _connection = connection;

            _transaction = transaction;

            _table = table;
        }

        public async Task<Result_Response<IEnumerable<TEntity>>> Get_all_Information()
        {
            var Result_Response = new Result_Response<IEnumerable<TEntity>>();

            string Response = $"Select * From {_table}";

            Result_Response.Result = await _connection.QueryAsync<TEntity>(Response, transaction: _transaction);

            return Result_Response;
        }

        public async Task<Result_Response<TEntity>> Get_Entity_ID(Guid ID)
        {
            var Result_Response = new Result_Response<TEntity>();

            string Response = $"Select * From {_table} Where ID = @ID";
            
            Result_Response.Result =
                await _connection.QuerySingleOrDefaultAsync<TEntity>(Response, param: 
                new { ID = ID }, 
                transaction: _transaction);

            if (Result_Response.Result is null)
            {
                Result_Response.Message = $"We could not found entity with ID {ID} in {this.Get_Entity_ID(ID).GetType().Name} method!";
                Result_Response.Success = false;
                throw new Exception($"Entity with ID {ID} could not be found!");
            }

            return Result_Response;
        }

        public async Task<Result_Response<IEnumerable<TEntity>>> Insert_Entity(TEntity entity)
        {
            var Result_Response = new Result_Response<IEnumerable<TEntity>>();

            entity.Created_at = DateTime.Now;

            entity.Updated_at = DateTime.Now;

            string Response = this.Generate_Insert_Query();

            await _connection.ExecuteAsync(Response, param: entity, transaction: _transaction);

            Result_Response.Result = await _connection.QueryAsync<TEntity>($"Select * From {_table}", transaction: _transaction);

            return Result_Response;
        }

        public async Task<Result_Response<IEnumerable<TEntity>>> Update_Entity(TEntity entity)
        {
            var Result_Response = new Result_Response<IEnumerable<TEntity>>();

            entity.Created_at = DateTime.Now;

            entity.Updated_at = DateTime.Now;

            try
            {
                string Response = this.Generate_Update_Query();

                await _connection.ExecuteAsync(Response, param: entity, transaction: _transaction);
            }
            catch (Exception exceptions)
            {
                Result_Response.Message = "We have the problem with Insert Statemen!";
                Result_Response.Success = false;
                throw new Exception($"Something went wrong in {this.Update_Entity(entity).GetType().Name} method! {exceptions.Message}");
            }

            Result_Response.Result = await _connection.QueryAsync<TEntity>($"Select * From {_table}", transaction: _transaction);

            return Result_Response;
        }

        public async Task<Result_Response<IEnumerable<TEntity>>> Delete_Entity(Guid ID)
        {
            var Result_Response = new Result_Response<IEnumerable<TEntity>>();

            string Response = $"Delete from {_table} where ID = @ID";

            await _connection.ExecuteAsync(Response, new { ID = ID }, transaction: _transaction);

            Result_Response.Result = await _connection.QueryAsync<TEntity>($"Select * From {_table}", transaction: _transaction);

            return Result_Response;
        }

        private IEnumerable<PropertyInfo> Get_Properties => typeof(TEntity).GetProperties();

        private static List<string> List_Properties(IEnumerable<PropertyInfo> list_Properties)
        {
            return (from property in list_Properties let attributes = 
                property.GetCustomAttributes(typeof(DescriptionAttribute), false) where attributes.Length <= 0 ||
                (attributes[0] as DescriptionAttribute)?.Description != "ingore" select property.Name).ToList();
        }

        private string Generate_Insert_Query()
        {
            var builder = new StringBuilder($"Insert into {_table}");
            builder.Append(" (");

            var properties = List_Properties(Get_Properties);
            properties.ForEach(property => { builder.Append($"[{property}],");});

            builder.Remove(builder.Length - 1, 1).Append(") Values (");

            properties.ForEach(property => { builder.Append($"@{property},");});

            builder.Remove(builder.Length - 1, 1).Append(")");

            return builder.ToString();
        }

        private string Generate_Update_Query()
        {
            var builder = new StringBuilder($"Update {_table} set ");
            var properties = List_Properties(Get_Properties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    builder.Append($"{property} = @{property},");
                }
            });

            builder.Remove(builder.Length - 1, 1).Append(" Where Id = @Id");

            return builder.ToString();
        }
    }
}
