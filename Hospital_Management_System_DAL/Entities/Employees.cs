﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Base_Entity;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Employees : Entity
    {
        public string First_name { get; set; } = string.Empty;

        public string Last_name { get; set; } = string.Empty;
        
        public string User_name { get; set; } = string.Empty;
        
        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        
        public string Phone_number { get; set; } = string.Empty;

        public string Mobile_number { get; set; } = string.Empty;

        public bool Active_is { get; set; } = true;
    }
}
