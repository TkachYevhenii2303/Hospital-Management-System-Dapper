using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern
{
    public class Unit_of_Work : IUnit_of_Work
    {
        private IDbTransaction transaction;
        public Unit_of_Work(IDbTransaction transaction)
        {
            this.transaction = transaction;
        }

        public void Dispose()
        {
            this.transaction.Connection?.Close();
            this.transaction.Connection?.Dispose();
            this.transaction.Dispose();
        }

        public void Commit()
        {
            try
            {
                this.transaction.Commit();
            }
            catch (Exception exception)
            {
                this.transaction.Rollback();
                Console.WriteLine(exception);
            }
        }
    }
}
