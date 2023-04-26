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
        public ICompany_Repository Company_Repository { get; }

        public IEmployees_Repository Employees_Repository { get; }
        
        public IDepartment_Repository Department_Repository { get; }
        
        public void Complete();
    }
}
