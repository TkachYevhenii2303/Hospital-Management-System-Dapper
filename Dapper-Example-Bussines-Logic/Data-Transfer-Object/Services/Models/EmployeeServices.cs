using AutoMapper;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Employees_Response_DTO;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Models_Request_DTO;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Dapper_Example_Bussines_Logic.Data_Transfer_Object.Services.Models
{
    public class EmployeeServices : IEmployeeServices
    {
        protected SqlConnection _connection;
        
        protected IDbTransaction _transaction;

        public EmployeeServices(IDbTransaction transaction, SqlConnection connection)
        {
            _transaction = transaction;
            _connection = connection;
        }

        public async Task<IEnumerable<Get_Employee_Response_DTO>> Get_all_Employees()
        {
            string query = "Select * From Employees";

            return await _connection.QueryAsync<Get_Employee_Response_DTO>
                (query, transaction: _transaction);
        }

        public async Task<Get_Employee_Response_DTO> Insert_Employee(Insert_Employees_Request_DTO entity)
        {
            entity.Created_at = DateTime.Now;

            entity.Updated_at = DateTime.Now;

            string query = "Insert into dbo.Employees ([First_name], [Last_name], [User_name], " +
                "[Active_is], [Email], [Mobile_number], [Phone_number], [Password]) Values " +
                "(@[First_name], @[Last_name], @[User_name], @[Active_is], @[Email], @[Mobile_number], @[Phone_number], @[Password])";

            var parameters = new DynamicParameters();
            parameters.Add("[First_name]", entity.First_name, DbType.String);
            parameters.Add("[Last_name]", entity.Last_name, DbType.String);
            parameters.Add("[User_name]", entity.User_name, DbType.String);
            parameters.Add("[Active_is]", entity.Active_is, DbType.Boolean);
            parameters.Add("[Email]", entity.Email, DbType.String);
            parameters.Add("[Mobile_number]", entity.Mobile_number, DbType.String);
            parameters.Add("[Phone_number]", entity.Phone_number, DbType.String);
            parameters.Add("[Password]", entity.Password, DbType.String);


            return (Get_Employee_Response_DTO)await _connection.QueryAsync<Get_Employee_Response_DTO>
                (query, parameters, transaction: _transaction);
        }
    }
}
