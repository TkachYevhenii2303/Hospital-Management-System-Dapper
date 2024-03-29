﻿using Dapper_Data_Access_Layer.Base_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Patients : Entity
    {
        public string First_title { get; set; } = string.Empty;

        public string Last_title { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;
    }
}
