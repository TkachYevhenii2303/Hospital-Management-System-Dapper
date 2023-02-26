using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern;
using Microsoft.Data.SqlClient;

namespace Dapper_Data_Access_Layer.Repository.Contracts
{
    public class HasRoleRepository : RepositoryBase<HasRole>, IHasRoleRepository
    {
        public HasRoleRepository(SqlConnection connection, IDbTransaction transaction) : base(connection, transaction, "Has_Role")
        {
        }
    }
}
