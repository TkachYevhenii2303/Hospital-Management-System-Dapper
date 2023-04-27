using Dapper_Data_Access_Layer.Bogus_Generator;
using Dapper_Data_Access_Layer.Entities_Repositories;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Console.Employees_Configurations
{
    public class Seeding_all_Datas<TRepository> 
        where TRepository : class
    {
        private readonly SqlConnection connections;

        private readonly SqlTransaction transaction;

        public Seeding_all_Datas(string connections_strings)
        {
            connections = new SqlConnection(connections_strings);

            transaction = connections.BeginTransaction();
        }

        public static async Task Connections_with_Database_and_Seeding(string connections_strings)
        {
            var connections = new SqlConnection(connections_strings);

            await connections.OpenAsync();

            var transactions = await connections.BeginTransactionAsync();

            var Employees_Repository = new Employees_Repository(connection: connections, transaction: transactions);

            var Employees_Bogus = Seeding_Data.Seeding_Employees();

            try
			{
                foreach (var Employees in Employees_Bogus)
                {
                    await Employees_Repository.Insert_Entity(Employees);
                }

                await Console.Out.WriteLineAsync($"The seeding for the {Employees_Repository.GetType().Name} complete!!!");
            }
			catch (Exception exception)
			{
                throw new Exception($"Something went wrong while seeding Database!!! {exception.Message}");
			}
            finally
            {
                await transactions.CommitAsync();

                await connections.CloseAsync();
            }
        }
    }
}
