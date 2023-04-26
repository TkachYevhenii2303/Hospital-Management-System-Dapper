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
using AutoMapper;
using Bogus;

namespace Dapper_Data_Access_Layer.Repository.Contracts
{
    public class Employees_Repository : GenericRepository<Employees>, IEmployees_Repository
    {
        public Employees_Repository(SqlConnection connection, IDbTransaction transaction) 
            : base(connection, transaction, "Employees")
        {
        }
    }
}
