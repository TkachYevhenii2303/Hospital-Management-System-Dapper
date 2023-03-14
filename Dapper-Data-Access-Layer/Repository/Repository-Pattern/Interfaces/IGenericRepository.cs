using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Base_Entity;
using Dapper_Data_Access_Layer.Entities;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        public Task<Services_Repsponse<IEnumerable<TEntity>>> Get_all_Information();
        public Task<Services_Repsponse<TEntity>> Get_by_Id(Guid id);
        public Task Insert_Entity(TEntity entity);
        public Task Update_Entity(TEntity entity);
        public Task Delete_Entity(Guid id);
    }
}
