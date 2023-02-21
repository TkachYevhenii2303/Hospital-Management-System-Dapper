using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Context;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;

namespace Dapper_Data_Access_Layer.Repository.Contracts
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly DapperContext _context;
        public GenericRepository(DapperContext context) => _context = context;
    }
}
