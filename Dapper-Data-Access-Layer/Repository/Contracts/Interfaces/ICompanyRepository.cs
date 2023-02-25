using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Example_Bussines_Logic.Dto;

namespace Dapper_Data_Access_Layer.Repository.Contracts.Interfaces
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Clinic>> GetCompanies();
        public Task<Clinic> GetCompany(int id);
        public Task<Clinic> CreateCompany (CompanyForCreationDto company);
        public Task UpdateCompany (int id, CompanyForCreationDto company);
        public Task DeleteCompany(int id);
        public Task<Clinic> CompanyDepartmentId (int id);
    }
}
