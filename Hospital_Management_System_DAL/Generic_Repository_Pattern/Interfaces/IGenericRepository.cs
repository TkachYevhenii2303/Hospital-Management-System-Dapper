using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Base_Entity;
using Dapper_Data_Access_Layer.Entities;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces
{
    public interface IGenericRepository<TEntity> 
        where TEntity : Entity
    {
        public Task<Result_Response<IEnumerable<TEntity>>> Get_all_Information();
        
        public Task<Result_Response<TEntity>> Get_Entity_ID(Guid ID);

        public Task<Result_Response<IEnumerable<TEntity>>> Insert_Entity(TEntity entity);
        
        public Task<Result_Response<IEnumerable<TEntity>>> Update_Entity(TEntity entity);
        
        public Task<Result_Response<IEnumerable<TEntity>>> Delete_Entity(Guid ID);
    }
}
