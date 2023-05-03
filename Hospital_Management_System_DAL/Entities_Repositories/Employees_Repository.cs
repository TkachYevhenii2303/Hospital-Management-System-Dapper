using Dapper;
using Dapper_Data_Access_Layer.Data_transfer_objects_on_DAL.Response_Result_DTO;
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

        public List<string> Get_Departments_title_ID(Guid ID)
        {
            string Response = "SELECT DISTINCT d.Department_title " +
                "FROM Employees e " +
                "INNER JOIN In_Departments id ON e.ID = id.Employees_ID " +
                "INNER JOIN Department d ON d.Id = id.Departments_ID " +
                "WHERE e.ID = @ID;";

            var Result = connections.Query<string>(Response,
                param: new { ID = ID },
                transaction: transactions);

            return Result.ToList();
        }

        public async Task<Result_Response<Employees>> Get_Employees_and_Departments(Guid ID)
        {
            var Result_Response = new Result_Response<Employees>();
            var procedures = "Employees_and_Departments_Server";
            var parameters = new DynamicParameters();

            parameters.Add("ID", ID, DbType.Guid, ParameterDirection.Input);
          
            Result_Response.Result = await connections.QueryFirstOrDefaultAsync<Employees>
                (procedures, parameters, transaction: transactions, commandType: CommandType.StoredProcedure);

            Result_Response.Message = "Stored Procedure Employees_and_Departments is Completed!!! Everything is good!";

            return Result_Response;
        }
    }
}
