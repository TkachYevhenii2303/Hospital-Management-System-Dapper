﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> Get_all_Information();
    }
}
