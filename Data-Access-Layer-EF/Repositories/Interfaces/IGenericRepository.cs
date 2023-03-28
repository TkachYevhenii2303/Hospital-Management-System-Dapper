using Data_Access_Layer_EF.Base_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
    }
}
