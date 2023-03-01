using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Example_Bussines_Logic.DTO_Models
{
    public class Company_Response
    {
        public string Clinic_name { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string Details { get; set; } = String.Empty;
    }
}
