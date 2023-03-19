using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern
{
    public class Unit_of_Work : IUnit_of_Work
    {
        private IDbTransaction transaction;

        public ICompanyRepository CompanyRepository { get; }
        
        public IEmployeesRepository EmployeesRepository { get; }
        
        public IDepartmentRepository DepartmentRepository { get; }
        
        public Unit_of_Work(IDbTransaction transaction, ICompanyRepository companyRepository, IEmployeesRepository employeesRepository, 
            IDepartmentRepository departmentRepository)
        {
            this.transaction = transaction;
            CompanyRepository = companyRepository;
            EmployeesRepository = employeesRepository;
            DepartmentRepository = departmentRepository;
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
