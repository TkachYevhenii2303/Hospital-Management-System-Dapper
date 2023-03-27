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
    public class RepositoryBase<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        protected SqlConnection _connection;
        protected IDbTransaction _transaction;
        protected string _table;

        public RepositoryBase(SqlConnection connection, IDbTransaction transaction, string table)
        {
            _connection = connection;
            _transaction = transaction;
            _table = table;
        }
        /// <summary>
        /// This method returned the all information about table
        /// </summary>
        /// <returns>IEnumerable(TEntity)></returns>
        public virtual async Task<IEnumerable<TEntity>> Get_all_Information()
        {
            var query = $"Select * From {_table}";
            return await _connection.QueryAsync<TEntity>(query, transaction: _transaction);
        }

        /// <summary>
        /// This method returned entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity</returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<TEntity> Get_by_Id(Guid id)
        {
            string query = $"Select * From {_table} Where Id = @Id";
            var result =
                await _connection.QuerySingleOrDefaultAsync<TEntity>(query, param: 
                new { Id = id }, 
                transaction: _transaction);

            if (result == null)
            {
                throw new KeyNotFoundException($"{_table} with id [{id}] could not be found.");
            }

            return result;
        }

        /// <summary>
        /// This method Insert new entity into table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> Insert_Entity(TEntity entity)
        {
            entity.Created_at = DateTime.Now;
            entity.Updated_at = DateTime.Now;

            string query = this.Generate_Insert_Query();

            await _connection.ExecuteAsync(query, param: entity, transaction: _transaction);

            return await _connection.QueryAsync<TEntity>($"Select * From {_table}", transaction: _transaction);
        }

        /// <summary>
        /// This method Update the some entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> Update_Entity(TEntity entity)
        {
            entity.Created_at = DateTime.Now;
            entity.Updated_at = DateTime.Now;

            string query = this.Generate_Update_Query();

            await _connection.ExecuteAsync(query, param: entity, transaction: _transaction);

            return await _connection.QueryAsync<TEntity>($"Select * From {_table}", transaction: _transaction);
        }

        /// <summary>
        /// This method can delete the entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> Delete_Entity(Guid id)
        {
            string query = $"Delete from {_table} where Id = @Id";
            await _connection.ExecuteAsync(query, new { Id = id }, transaction: _transaction);

            return await _connection.QueryAsync<TEntity>($"Select * From {_table}", transaction: _transaction);
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
