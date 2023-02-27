using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Example_Bussines_Logic.Dto
{
    public class EmployeesForCreationDto
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string User_name { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? Phone_number { get; set; }
        public string? Mobile_number { get; set; }
        public bool Active_is { get; set; }
    }
}
