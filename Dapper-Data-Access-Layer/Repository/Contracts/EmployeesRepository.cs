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
using Microsoft.Data.SqlClient;

namespace Dapper_Data_Access_Layer.Repository.Contracts
{
    public class EmployeesRepository : RepositoryBase<Employees>, IEmployeesRepository
    {
        public EmployeesRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction, "Employees")
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
    }
}
