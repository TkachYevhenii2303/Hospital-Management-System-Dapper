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
    public class Company_Repository : GenericRepository<Hospital>, ICompany_Repository
    {
        public Company_Repository(SqlConnection connection, IDbTransaction transaction) 
            : base(connection, transaction, "Clinic")
        {
        }
    }
}
