using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDepartmentRepository departmentRepository { get; }

        private readonly IDbTransaction transaction;
        public UnitOfWork(IDbTransaction transaction, IDepartmentRepository departmentRepository)
        {
            this.transaction = transaction;
            this.departmentRepository = departmentRepository;
        }
        public void Dispose()
        {
           transaction.Connection?.Close();
           transaction.Connection?.Dispose();
           transaction?.Dispose();
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
                Console.WriteLine(exception.Message);
            }
        }
    }
}
