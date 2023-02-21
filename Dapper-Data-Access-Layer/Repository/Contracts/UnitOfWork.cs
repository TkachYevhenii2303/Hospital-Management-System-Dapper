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
        private readonly IDbTransaction transaction;
        public void Commit()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            transaction?.Connection.Close();
        }
    }
}
