using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Dapper_Example_Bussines_Logic.DTO_Models;
using Dapper_Example_Bussines_Logic.Services.Interfaces;

namespace Dapper_Example_Bussines_Logic.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly IUnit_of_Work _unit_of_Work;
        public CompanyServices(IUnit_of_Work unitOfWork)
        {
            _unit_of_Work = unitOfWork;
        }
        public async Task<Company_Response> Get_Concrete_Company(int id)
        {
            var Clinic = await _unit_of_Work.CompanyRepository.Get_by_Id(id);
            var Clinic_Response = new Company_Response();

            Clinic_Response.Clinic_name = Clinic.Clinic_name;
            Clinic_Response.Address = Clinic.Address;
            Clinic_Response.Details = Clinic.Details;

            return Clinic_Response;
        }
    }
}
