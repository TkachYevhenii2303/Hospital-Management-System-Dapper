using AutoMapper;
using Dapper_Data_Access_Layer.Data_transfer_objects_on_DAL.Response_Result_DTO;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Entities_Repositories;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Dapper_Example_Bussines_Logic.Data_trasfer_objects.Request_Result_DTO;
using Dapper_Example_Bussines_Logic.Data_trasfer_objects.Response_Result_DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_API.Mapping
{
    public class AutoMapping : Profile
    {
        private readonly IUnit_of_Work _Unit_of_Work;

        public AutoMapping(IUnit_of_Work unit_of_Work)
        {
            _Unit_of_Work = unit_of_Work;

            this.Employees_Mapping();

            this.Result_Response_Mapping();
        }

        //TODO: Fix the problem with the List<String> Department_title { get; set} from the Data transfer object Employee_and_Department_ID 
        private void Employees_Mapping()
        {
            CreateMap<Employees, Employees_Response_DTO>().ReverseMap();
            CreateMap<Employees_Request_DTO, Employees>();
            CreateMap<Employees_Request_Update_DTO, Employees>();
            CreateMap<Employees, Employees_Departments_Result_DTO>()
                .ForMember(destinations => destinations.Department_title, options => options
                .MapFrom(source => _Unit_of_Work.Employees_Repository.Get_Departments_title_ID(source.ID)));
        }

        private void Result_Response_Mapping()
        {
            CreateMap(typeof(Result_Response<>), typeof(Result_Response<>));
        }
    }
}
