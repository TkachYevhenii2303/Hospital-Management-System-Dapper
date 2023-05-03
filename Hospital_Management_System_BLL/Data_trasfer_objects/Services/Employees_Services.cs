using AutoMapper;
using Dapper_Data_Access_Layer.Data_transfer_objects_on_DAL.Response_Result_DTO;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Dapper_Example_Bussines_Logic.Data_trasfer_objects.Request_Result_DTO;
using Dapper_Example_Bussines_Logic.Data_trasfer_objects.Response_Result_DTO;
using Dapper_Example_Bussines_Logic.Data_trasfer_objects.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Example_Bussines_Logic.Data_trasfer_objects.Services
{
    public class Employees_Services : IEmployees_Services
    {
        private readonly IUnit_of_Work _Unit_of_Work;

        private readonly IMapper _mapper;

        public Employees_Services(IUnit_of_Work unit_of_Work, IMapper mapper)
        {
            _Unit_of_Work = unit_of_Work;

            _mapper = mapper;
        }

        public async Task<Result_Response<IEnumerable<Employees_Response_DTO>>> Delete_Employee(Guid ID)
        {
            var result = await _Unit_of_Work.Employees_Repository.Delete_Entity(ID);

            _Unit_of_Work.Complete();

            return _mapper.Map<Result_Response<IEnumerable<Employees>>, Result_Response<IEnumerable<Employees_Response_DTO>>>(result);
        }

        public async Task<Result_Response<IEnumerable<Employees_Response_DTO>>> Get_all_Employees()
        {
            var result = await _Unit_of_Work.Employees_Repository.Get_all_Information();

            return _mapper.Map<Result_Response<IEnumerable<Employees>>, Result_Response<IEnumerable<Employees_Response_DTO>>>(result);
        }

        public async Task<Result_Response<Employees_Response_DTO>> Get_Employee_ID(Guid ID)
        {
            var result = await _Unit_of_Work.Employees_Repository.Get_Entity_ID(ID);

            return _mapper.Map<Result_Response<Employees>, Result_Response<Employees_Response_DTO>>(result);
        }

        public async Task<Result_Response<IEnumerable<Employees_Response_DTO>>> Insert_Employee(Employees_Request_DTO Employee)
        {
            var result = await _Unit_of_Work.Employees_Repository.Insert_Entity(_mapper.Map<Employees>(Employee));

            _Unit_of_Work.Complete();

            return _mapper.Map<Result_Response<IEnumerable<Employees>>, Result_Response<IEnumerable<Employees_Response_DTO>>>(result);
        }

        public async Task<Result_Response<IEnumerable<Employees_Response_DTO>>> Update_Employee(Employees_Request_Update_DTO Employee)
        {
            var result = await _Unit_of_Work.Employees_Repository.Update_Entity(_mapper.Map<Employees>(Employee));

            _Unit_of_Work.Complete();

            return _mapper.Map<Result_Response<IEnumerable<Employees>>, Result_Response<IEnumerable<Employees_Response_DTO>>>(result);
        }

        public async Task<Result_Response<Employees_Departments_Result_DTO>> Get_Employees_and_Departments_ID(Guid ID)
        {
            var result = await _Unit_of_Work.Employees_Repository.Get_Employees_and_Departments(ID);

            return _mapper.Map<Result_Response<Employees>, Result_Response<Employees_Departments_Result_DTO>>(result);
        }

        public List<string> Get_all_Departments_titles_ID(Guid ID)
        {
            var result = _Unit_of_Work.Employees_Repository.Get_Departments_title_ID(ID);

            return result;
        }
    }
}
