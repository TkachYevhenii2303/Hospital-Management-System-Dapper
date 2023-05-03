using Dapper;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Entities_Repositories.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Dapper_Data_Access_Layer.Entities_Repositories
{
    public class Employees_Repository : GenericRepository<Employees>, IEmployees_Repository
    {
        private readonly SqlConnection connections;

        private readonly IDbTransaction transactions;

        public Employees_Repository(SqlConnection connection, IDbTransaction transaction) : base(connection, transaction, "Employees")
        {
            connections = connection;

            transactions = transaction;
        }

        public async Task<IEnumerable<String>> Get_all_Departments_titles_ID(Guid ID)
        {
            string Response = "Select Department.Department_title From Employees " +
                "Inner join In_Departments on Employees.ID = In_Departments.Employees_ID " +
                "Inner join Department on Department.Id = In_Departments.Departments_ID " +
                "Where Employees.ID = @ID";

            var Result = await connections.QueryAsync<String>(Response, 
                param: new { ID = ID }, 
                transaction: transactions);

            return Result;
        }

        public async Task<Result_Response<IEnumerable<Employees>>> Get_Employees_and_Departments(Guid ID)
        {
            var Result_Response = new Result_Response<IEnumerable<Employees>>();
            var procedures = "Employees_and_Departments";
            var parameters = new DynamicParameters();

            parameters.Add("ID", ID, DbType.Guid, ParameterDirection.Input);

            Result_Response.Result = await SqlMapper.QueryAsync<Employees>(connections, procedures, parameters, transactions, commandType: CommandType.StoredProcedure);

            Result_Response.Message = "Stored Procedure Employees_and_Departments is Completed!!! Everything is good!";

            return Result_Response;
        }
    }
}
