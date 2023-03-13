using Dapper_Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Example_Bussines_Logic.DTO.Services.Contaracts
{
    public interface IEmployeerManager
    {
        public Task<IEnumerable<ResponseEmployeerInformation>> GetEmployeeByName (string employeerName);
    }
}
