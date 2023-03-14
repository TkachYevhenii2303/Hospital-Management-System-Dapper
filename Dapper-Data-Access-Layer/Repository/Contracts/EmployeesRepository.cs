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

namespace Dapper_Data_Access_Layer.Repository.Contracts
{
    public class EmployeesRepository : RepositoryBase<Employees>, IEmployeesRepository
    {
        private readonly IMapper _mapper;

        public EmployeesRepository(SqlConnection connection, IDbTransaction transaction, IMapper mapper) 
            : base(connection, transaction, "Employees")
        {
            _mapper = mapper;
        }

        public async Task<Services_Repsponse<IEnumerable<Employees>>> Get_all_activity_Employees()
        {
            string query = "Select * From [dbo].Employees Where Active_is = 1";
            var result = (Services_Repsponse<IEnumerable<Employees>>)await _connection.QueryAsync<Employees>(query, transaction: _transaction);
            return result;
        }
    }
}
