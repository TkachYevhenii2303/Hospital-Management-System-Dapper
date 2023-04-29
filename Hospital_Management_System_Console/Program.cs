using Dapper_Data_Access_Layer.Bogus_Generator;
using Dapper_Data_Access_Layer.Entities;
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
            var connections = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnections"].ConnectionString);
            
            await connections.OpenAsync();

            var transactions = await connections.BeginTransactionAsync();

            Seeding_all_Dates<Employees_Repository, Employees> Seeding_Informations 
                = new Seeding_all_Dates<Employees_Repository, Employees>(Seeding_Bogus.Seeding_Employees, new Employees_Repository(connections, transactions), transactions);

            await Seeding_Informations.Seeding_Repositories();

            Console.ReadLine();
        }
    }
}