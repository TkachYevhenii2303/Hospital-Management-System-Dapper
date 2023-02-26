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
using Dapper_Example_Bussines_Logic.Dto;
using Microsoft.Data.SqlClient;

namespace Dapper_Data_Access_Layer.Repository.Contracts
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;
        public CompanyRepository(DapperContext context) => _context = context;
        public async Task<IEnumerable<Clinic>> GetCompanies()
        {
            var query = "Select * From dbo.Clinic";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Clinic>(query);
                return companies.ToList();
            }
        }

        public async Task<Clinic> GetCompany(int id)
        {
            var query = "Select * From dbo.Clinic Where Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Clinic>(query, new { id });
                return company;
            }
        }

        public async Task<Clinic> CreateCompany(CompanyForCreationDto company)
        {
            var query = "Insert into Clinic (Clinic_name, Address, Details) Values (@Clinic_name, @Address, @Details) " +
                        "Select Cast(Scope_Identity() as int)";
            var parameters = new DynamicParameters();

            parameters.Add("Clinic_name", company.Clinic_name, DbType.String);
            parameters.Add("Address", company.Address, DbType.String);
            parameters.Add("Details", company.Details, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdCompany = new Clinic
                {
                    Id = id,
                    Clinic_name = company.Clinic_name,
                    Address = company.Address,
                    Details = company.Details
                };

                return createdCompany;
            }
        }

        public async Task UpdateCompany(int id, CompanyForCreationDto company)
        {
            var query = "Update Clinic SET Clinic_name = @Clinic_name, Address = @Address, Details = @Details WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Clinic_name", company.Clinic_name, DbType.String);
            parameters.Add("Address", company.Address, DbType.String);
            parameters.Add("Details", company.Details, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCompany(int id)
        {
            var query = "Delete From Clinic Where Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new {id});
            }
        }

        public async Task<Clinic> CompanyDepartmentId(int id)
        {
            var procedureName = "Show_Company_and_Departments";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryFirstOrDefaultAsync<Clinic>(procedureName, parameters,
                    commandType: CommandType.StoredProcedure);

                return companies;
            }
        }

        public async Task<List<Clinic>> GetCompaniesMultiMapping()
        {
            var query = "Select * From Clinic c Join Department d on c.Id = d.Clinic_id";

            using (var connection = _context.CreateConnection())
            {
                var companyDictionary = new Dictionary<int, Clinic>();

                var companies = await connection.QueryAsync<Clinic, Department, Clinic>
                (
                    query, (company, department) =>
                    {
                        if (!companyDictionary.TryGetValue(company.Id, out var currentCompany))
                        {
                            currentCompany = company;
                            companyDictionary.Add(currentCompany.Id, currentCompany);
                        }

                        currentCompany.Departments.Add(department);
                        return currentCompany;
                    }
                );

                return companies.Distinct().ToList();
            }
        }

        public  async Task CreateMultipleCompanies(List<CompanyForCreationDto> companies)
        {
            var query = "Insert into Clinic (Clinic_name, Address, Details) Values (@Clinic_name, @Address, @Details)";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var company in companies)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("Clinic_name", company.Clinic_name, DbType.String);
                        parameters.Add("Address", company.Address, DbType.String);
                        parameters.Add("Details", company.Details, DbType.String);

                        await connection.ExecuteAsync(query, parameters, transaction: transaction);
                    }

                    transaction.Commit();
                }
            }
        }
    }
}
