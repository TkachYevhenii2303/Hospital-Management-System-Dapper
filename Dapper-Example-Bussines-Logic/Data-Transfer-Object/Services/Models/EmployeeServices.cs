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

        public async Task<IEnumerable<Get_Employee_Response_DTO>> Get_all_Employees()
        {
            string query = "Select * From Employees";

            var result = await _unit_Of_Work.EmployeesRepository.Get_all_Information();

            return _mapper.Map<IEnumerable<Employees>, IEnumerable<Get_Employee_Response_DTO>>(result);
        }

        /*public async Task<Get_Employee_Response_DTO> Insert_Employee(Insert_Employees_Request_DTO entity)
        {
            entity.Created_at = DateTime.Now;

            entity.Updated_at = DateTime.Now;

            string query = "Insert into dbo.Employees ([First_name], [Last_name], [User_name], " +
                "[Active_is], [Email], [Mobile_number], [Phone_number], [Password]) Values " +
                "(@[First_name], @[Last_name], @[User_name], @[Active_is], @[Email], @[Mobile_number], @[Phone_number], @[Password])";

            var parameters = new DynamicParameters();
            parameters.Add("[First_name]", entity.First_name, DbType.String);
            parameters.Add("[Last_name]", entity.Last_name, DbType.String);
            parameters.Add("[User_name]", entity.User_name, DbType.String);
            parameters.Add("[Active_is]", entity.Active_is, DbType.Boolean);
            parameters.Add("[Email]", entity.Email, DbType.String);
            parameters.Add("[Mobile_number]", entity.Mobile_number, DbType.String);
            parameters.Add("[Phone_number]", entity.Phone_number, DbType.String);
            parameters.Add("[Password]", entity.Password, DbType.String);


            return (Get_Employee_Response_DTO)await _connection.QueryAsync<Get_Employee_Response_DTO>
                (query, parameters, transaction: _transaction);
        }*/
    }
}
