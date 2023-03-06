using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Dapper_Data_Access_Layer.Dapper
{
    public class Context
    {
        private readonly IConfiguration _configuration;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Create_Master_Connection()
            => new SqlConnection(_configuration.GetConnectionString("MasterConnection"));
    }
}
