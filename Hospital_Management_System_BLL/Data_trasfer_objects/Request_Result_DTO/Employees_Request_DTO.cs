using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Example_Bussines_Logic.Data_trasfer_objects.Request_Result_DTO
{
    public class Employees_Request_DTO
    {
        public string First_title { get; set; } = string.Empty;

        public string Last_title { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;
    }
}
