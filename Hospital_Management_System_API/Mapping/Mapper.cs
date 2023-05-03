using AutoMapper;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Entities_Repositories;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Dapper_Example_Bussines_Logic.Data_trasfer_objects.Request_Result_DTO;
using Dapper_Example_Bussines_Logic.Data_trasfer_objects.Response_Result_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_API.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            this.Employees_Mapping();
            this.Result_Response_Mapping();
        }

        private void Employees_Mapping()
        {
            CreateMap<Employees, Employees_Response_DTO>().ReverseMap();
            CreateMap<Employees_Request_DTO, Employees>();
            CreateMap<Employees_Request_Update_DTO, Employees>();
            CreateMap<Employees, Employees_Departments_Result_DTO>()
                .ForMember(destination => destination.Department_title,
                options => options.MapFrom(sourse => "Hello!"));
        }

        private void Result_Response_Mapping()
        {
            CreateMap(typeof(Result_Response<>), typeof(Result_Response<>));
        }
    }
}
