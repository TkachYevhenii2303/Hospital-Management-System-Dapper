using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Employees
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string User_name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }
        public string Mobile_number { get; set; }
        public bool Active_is { get; set; }
    }
}
