using AutoMapper;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Employees_Response_DTO;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Models_Request_DTO;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Example_Bussines_Logic.Data_Transfer_Object.Models_Request_DTO.Employees_Services_DTO;

namespace Dapper_Example_Bussines_Logic.Data_Transfer_Object.Services.Models
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IUnit_of_Work _unit_Of_Work;

        private readonly IMapper _mapper;

        public EmployeeServices(IUnit_of_Work unit_Of_Work, IMapper mapper)
        {
            this._unit_Of_Work = unit_Of_Work;
            _mapper = mapper;
        }

        // Deleting some Entity using ID!
        public async Task<IEnumerable<Get_Employee_Response_DTO>> Delete_Employees(Guid Id)
        {
            var result = await _unit_Of_Work.EmployeesRepository.Delete_Entity(Id);

            _unit_Of_Work.Commit();

            return _mapper.Map<IEnumerable<Employees>, IEnumerable<Get_Employee_Response_DTO>>(result);
        }

        // Method for get all employee from database using Services to access to Employee Repository
        public async Task<IEnumerable<Get_Employee_Response_DTO>> Get_all_Employees()
        {
            var result = await _unit_Of_Work.EmployeesRepository.Get_all_Information();

            // Using Mapping Collection-to-Collection
            return _mapper.Map<IEnumerable<Employees>, IEnumerable<Get_Employee_Response_DTO>>(result);
        }

        // Creating method for get the employee by Id as parameter and map it to Get_Employee_Object
        public async Task<Get_Employee_Response_DTO> Get_Employee_ID(Guid Id)
        {
            var result = await _unit_Of_Work.EmployeesRepository.Get_by_Id(Id);

            return _mapper.Map<Get_Employee_Response_DTO>(result);
        }

        // Insert the entity to the database using AutoMapper!
        public async Task<IEnumerable<Get_Employee_Response_DTO>> Insert_Employee(Insert_Employees_Request_DTO entity)
        {
            var result = await _unit_Of_Work.EmployeesRepository.Insert_Entity(_mapper.Map<Employees>(entity));

            _unit_Of_Work.Commit(); 

            return _mapper.Map<IEnumerable<Employees>, IEnumerable<Get_Employee_Response_DTO>>(result);
        }

        // Update entity by Id in Insert List
        public async Task<IEnumerable<Get_Employee_Response_DTO>> Update_Employee(Update_Employees_Request_DTO entity)
        {
            var result = await _unit_Of_Work.EmployeesRepository.Update_Entity(_mapper.Map<Employees>(entity));

            _unit_Of_Work.Commit();

            return _mapper.Map<IEnumerable<Employees>, IEnumerable<Get_Employee_Response_DTO>>(result);
        }
    }
}
