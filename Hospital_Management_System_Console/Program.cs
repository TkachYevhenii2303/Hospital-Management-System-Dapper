using Dapper_Data_Access_Layer.Bogus_Generator;
using Dapper_Data_Access_Layer.Entities_Repositories;
using Hospital_Management_System_Console.Employees_Configurations;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Hospital_Management_System_Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var Default_Connections = ConfigurationManager.ConnectionStrings["DefaultConnections"].ConnectionString;

            await Seeding_all_Datas.Connections_with_Database_and_Seeding(Default_Connections);

            Console.ReadLine();
        }
    }
}