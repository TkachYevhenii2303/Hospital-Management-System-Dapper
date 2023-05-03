using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Data_transfer_objects_on_DAL.Response_Result_DTO
{
    public class Employees_with_Department_DTO
    {
        public string First_title { get; set; } = string.Empty;

        public string Last_title { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public IEnumerable<String> Department_title { get; set; } = new List<String>();
    }
}
