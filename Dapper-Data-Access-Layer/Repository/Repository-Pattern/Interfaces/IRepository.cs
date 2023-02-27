using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces
{
    public interface IRepository<TEntity>
    {
        public Task<IEnumerable<TEntity>> Get_all_Information();
        public Task<TEntity> Get_by_Id(int id);
        public Task Delete_Entity(int id);
    }
}
