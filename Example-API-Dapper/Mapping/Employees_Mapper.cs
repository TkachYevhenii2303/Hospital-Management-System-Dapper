using AutoMapper;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Employees_Response_DTO;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Models_Request_DTO;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Models_Request_DTO.Employees_Services_DTO;

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
        }
    }
}
