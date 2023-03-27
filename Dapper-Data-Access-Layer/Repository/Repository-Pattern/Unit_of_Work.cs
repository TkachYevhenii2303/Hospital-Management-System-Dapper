using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Microsoft.Data.SqlClient;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern
{
    public class Unit_of_Work : IUnit_of_Work
    {
        private IDbTransaction transaction;

        private SqlConnection connection;

        public ICompanyRepository CompanyRepository { get; }
        
        public IEmployeesRepository EmployeesRepository { get; }
        
        public IDepartmentRepository DepartmentRepository { get; }

        public Unit_of_Work(IDbTransaction transaction, ICompanyRepository companyRepository, IEmployeesRepository employeesRepository,
            IDepartmentRepository departmentRepository, SqlConnection connection)
        {
            this.transaction = transaction;
            CompanyRepository = companyRepository;
            EmployeesRepository = employeesRepository;
            DepartmentRepository = departmentRepository;
            this.connection = connection;
        }

        public void Dispose()
        {
            this.transaction.Connection?.Close();
            this.transaction.Connection?.Dispose();
            this.transaction.Dispose();
        }

        public void Commit()
        {
            try
            {
                this.transaction.Commit();
            }
            catch (Exception exception)
            {
                this.transaction.Rollback();
                Console.WriteLine(exception);
            }
        }
    }
}
