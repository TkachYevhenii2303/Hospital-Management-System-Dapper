using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces
{
    public interface IUnit_of_Work : IDisposable
    {
        public ICompanyRepository CompanyRepository { get; }
        public IEmployeesRepository EmployeesRepository { get; }
        public void Commit();
    }
}
