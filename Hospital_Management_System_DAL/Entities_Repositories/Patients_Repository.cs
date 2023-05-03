using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Entities_Repositories.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities_Repositories
{
    public class Patients_Repository : GenericRepository<Patients>, IPatients_Repository
    {
        public Patients_Repository(SqlConnection connection, IDbTransaction transaction) : base(connection, transaction, "Patients")
        {
        }
    }
}
