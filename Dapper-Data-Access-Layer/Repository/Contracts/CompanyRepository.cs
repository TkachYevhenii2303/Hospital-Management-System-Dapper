using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper_Data_Access_Layer.Context;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Microsoft.Data.SqlClient;

namespace Dapper_Data_Access_Layer.Repository.Contracts
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;
        public CompanyRepository(DapperContext context) => _context = context;
        public async Task<IEnumerable<Clinic>> GetCompanies()
        {
            string query = "Select * From dbo.Clinic";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Clinic>(query);
                return companies.ToList();
            }
        }

        public async Task<Clinic> GetCompany(int id)
        {
            string query = "Select * From dbo.Clinic Where Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Clinic>(query, new { id });
                return company;
            }
        }
    }
}
