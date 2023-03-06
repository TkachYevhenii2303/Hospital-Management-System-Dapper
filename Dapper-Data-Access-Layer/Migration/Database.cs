using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper_Data_Access_Layer.Dapper;

namespace Dapper_Data_Access_Layer.Migration
{
    public class Database
    {
        private readonly Context _context;

        public Database(Context context)
        {
            _context = context;
        }

        public void Create_Database(string table)
        {
            string query = "Select * From sys.databases Where name = @name";
            var parameters = new DynamicParameters();

            parameters.Add("name", table);

            using (var connection = _context.Create_Master_Connection()) 
            {
                var records = connection.Query(query, parameters);
                if (!records.Any())
                {
                    connection.Execute($"Create database {table}");
                }
            }
        }
    }
}
