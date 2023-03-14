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
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Employees_Response_DTO;
using AutoMapper;
using Bogus;

namespace Dapper_Data_Access_Layer.Repository.Contracts
{
    public class EmployeesRepository : RepositoryBase<Employees>, IEmployeesRepository
    {
        public EmployeesRepository(SqlConnection connection, IDbTransaction transaction, IMapper mapper) 
            : base(connection, transaction, "Employees")
        {
        }

        public async Task<IEnumerable<Employees>> Get_all_activity_Employees()
        {
            string query = "Select * From [dbo].Employees Where Active_is = 1";
            var result = await _connection.QueryAsync<Employees>(query, transaction: _transaction);
            return result;
        }
    }
}
