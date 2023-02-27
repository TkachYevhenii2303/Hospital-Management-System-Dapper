using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern;
using Dapper_Example_Bussines_Logic.Dto;
using Microsoft.Data.SqlClient;

namespace Dapper_Data_Access_Layer.Repository.Contracts
{
    public class EmployeesRepository : RepositoryBase<Employees>, IEmployeesRepository
    {
        public EmployeesRepository(SqlConnection connection, IDbTransaction transaction) : base(connection, transaction, "Employees")
        {
        }

        public async Task<IEnumerable<Employees>> Get_all_activity_Employees()
        {
            string query = "Select * From [dbo].Employees Where Active_is = 1";
            IEnumerable<Employees> result = await _connection.QueryAsync<Employees>(query, transaction: _transaction);
            return result;
        }

        public async Task<IEnumerable<Employees>> Get_all_Employees_By_Specialization(string specialization)
        {
            string query = "Select a.First_name, a.Last_name, b.Role_name " +
                           "From Employees a, Role b, Has_Role c " +
                           $"Where c.Employees_id = a.Id and c.Role_id = b.Id and b.Role_name = '{specialization}'";

            IEnumerable<Employees> result = await _connection.QueryAsync<Employees>(query, transaction: _transaction);
            return result;
        }

        public async Task<Employees> Create_Employee(EmployeesForCreationDto employee)
        {
            string query = "Insert into dbo.Employees(First_name, Last_name, User_name, Email, " +
                           "Password, Mobile_number, Phone_number, Active_is) " +
                           "Values (@First_name, @Last_name, @User_name, @Email, " +
                           "@Password, @Mobile_number, @Phone_number, @Active_is) " +
                           "Select Cast(Scope_Identity() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("First_name", employee.First_name, DbType.String);
            parameters.Add("Last_name", employee.Last_name, DbType.String);
            parameters.Add("User_name", employee.User_name, DbType.String);
            parameters.Add("Email", employee.Email, DbType.String);
            parameters.Add("Password", employee.Password, DbType.String);
            parameters.Add("Mobile_number", employee.Mobile_number, DbType.String);
            parameters.Add("Phone_number", employee.Phone_number, DbType.String);
            parameters.Add("Active_is", employee.Active_is, DbType.Boolean);

            var id = await _connection.QuerySingleAsync<int>(query, parameters, transaction: _transaction);

            var created_employee = new Employees
            {
                Id = id,
                First_name = employee.First_name,
                Last_name = employee.Last_name,
                User_name = employee.User_name,
                Email = employee.Email,
                Password = employee.Password,
                Mobile_number = employee.Mobile_number,
                Phone_number = employee.Phone_number,
                Active_is = employee.Active_is,
            };

            return created_employee;
        }
    }
}
