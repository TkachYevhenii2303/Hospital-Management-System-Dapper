using Dapper_Data_Access_Layer.Base_Entity;
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
    public class Seeding_all_Dates<TRepository, TEntity>
        where TRepository : class
    {
        private readonly Func<List<TEntity>> _Seeding_Bogus;

        private readonly TRepository _Repository;

        private readonly IDbTransaction _transaction;

        public Seeding_all_Dates(Func<List<TEntity>> Seeding_Bogus, TRepository Repository, IDbTransaction transaction)
        {
            _Seeding_Bogus = Seeding_Bogus;

            _Repository = Repository;

            _transaction = transaction;
        }

        public async Task Seeding_Repositories()
        {
            try
            {
                var Entities = _Seeding_Bogus.Invoke();

                var Inserting = _Repository.GetType().GetMethod("Insert_Entity");

                foreach (var Entity in Entities)
                {
                    await (Task)Inserting.Invoke(_Repository, new object[] { Entity });
                }

                _transaction.Commit();

                await Console.Out.WriteLineAsync($"The seeding for {typeof(TEntity).Name} is complete!!!");
            }
            catch (Exception exception)
            {
                throw new Exception($"Something went wrong while seeding Database!!! {exception.Message}");
            }
        }
    }
}
