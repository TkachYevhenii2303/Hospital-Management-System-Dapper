using AutoMapper;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Employees_Response_DTO;

namespace Example_API_Dapper.Mapping
{
    public class Employees_Mapper : Profile
    {
        public Employees_Mapper()
        {
            this.Get_Employees_Mapper();
        }

        private void Get_Employees_Mapper()
        {
            CreateMap<Employees, Get_Employee_Response_DTO>();
        }
    }
}
