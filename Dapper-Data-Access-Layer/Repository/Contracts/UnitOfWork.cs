using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;

namespace Dapper_Data_Access_Layer.Repository.Contracts
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbTransaction _transaction;
        public UnitOfWork(IDbTransaction transaction)
        {
            _transaction = transaction;
        }
        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception e)
            {
                _transaction.Rollback();
                Console.WriteLine(e.Message);
            }
        }
        public void Dispose()
        {
            _transaction?.Connection?.Close();
            _transaction?.Connection?.Dispose();
            _transaction?.Dispose();
        }
    }
}
