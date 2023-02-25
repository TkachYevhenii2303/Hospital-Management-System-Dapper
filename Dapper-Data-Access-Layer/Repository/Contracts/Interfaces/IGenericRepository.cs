using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Repository.Contracts.Interfaces
{
    public interface IGenericRepository<T>
    {
        public Task<IEnumerable<T>> Get_Information();
        public Task<T> Get_ID(int id);
        public Task Delete_ID(int id);
        public Task<int> Add_Range(IEnumerable<T> List);
        public Task Replace(T element);
        public Task<int> Add_Element(T element);
    }
}
