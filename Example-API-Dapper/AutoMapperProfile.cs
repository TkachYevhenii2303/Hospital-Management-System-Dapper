using AutoMapper;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Employees_Response_DTO;

namespace Example_API_Dapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.Employees_Mapper();
        }

        private void Employees_Mapper()
        {
            CreateMap<Employees, Get_Employee_Response_DTO>();
        }
    }
}
