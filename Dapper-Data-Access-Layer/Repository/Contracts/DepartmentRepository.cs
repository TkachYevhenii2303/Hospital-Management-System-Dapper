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
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction, "Department")
        {
        }

        public async Task<IEnumerable<Department>> Get_five_Departments()
        {
            var query = "Select top 5 * From Department";
            var result = await _connection.QueryAsync<Department>(query, transaction: _transaction);
            return result;
        }
    }
}
