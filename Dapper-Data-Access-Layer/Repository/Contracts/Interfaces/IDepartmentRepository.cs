﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;

namespace Dapper_Data_Access_Layer.Repository.Contracts.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        public Task<IEnumerable<Department>> Get_five_Departments();
    }
}
