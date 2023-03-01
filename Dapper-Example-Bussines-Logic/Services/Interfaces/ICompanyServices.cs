using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Example_Bussines_Logic.DTO_Models;

namespace Dapper_Example_Bussines_Logic.Services.Interfaces
{
    public interface ICompanyServices
    {
        public Task<IEnumerable<Company_Response>> Get_Concrete_Company(int id);
    }
}
