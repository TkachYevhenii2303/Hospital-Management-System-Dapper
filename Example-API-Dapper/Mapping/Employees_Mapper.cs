using AutoMapper;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Employees_Response_DTO;
<<<<<<< HEAD
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Models_Request_DTO;

namespace Example_API_Dapper.Mapping
{
    public class Mapper_Profile : Profile
    {
        public Mapper_Profile()
        {
            this.Employees_Mapper_Maps();
        }

        private void Employees_Mapper_Maps()
        {
            CreateMap<Employees, Get_Employee_Response_DTO>();
            CreateMap<Insert_Employees_Request_DTO, Employees>();
            CreateMap<Update_Employees_Request_DTO, Employees>();
=======

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
>>>>>>> 118e8dcef921536770ffbbcf6d4d185c0b971956
        }
    }
}
