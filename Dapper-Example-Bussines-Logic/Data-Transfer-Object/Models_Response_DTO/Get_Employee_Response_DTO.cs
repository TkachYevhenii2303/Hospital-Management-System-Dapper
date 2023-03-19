﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Example_Bussines_Logic.Data_Transfer_Object.Employees_Response_DTO
{
    public class Get_Employee_Response_DTO
    {
        public Guid Id { get; set; }

        public string First_name { get; set; } = string.Empty;

        public string Last_name { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Phone_number { get; set; }

        public string? Mobile_number { get; set; }

        public bool Active_is { get; set; }
    }
}
