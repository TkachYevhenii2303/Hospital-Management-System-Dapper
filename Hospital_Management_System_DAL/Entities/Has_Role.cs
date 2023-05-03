﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Base_Entity;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Has_Role : Entity
    {
        public Guid Employees_ID { get; set; }

        public Guid Roles_ID { get; set; }
    }
}
