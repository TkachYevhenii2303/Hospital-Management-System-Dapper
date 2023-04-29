using Dapper_Data_Access_Layer.Entities_Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces
{
    public interface IUnit_of_Work : IDisposable
    {
        public void Complete();

        public IEmployees_Repository Employees_Repository { get; }
    }
}
