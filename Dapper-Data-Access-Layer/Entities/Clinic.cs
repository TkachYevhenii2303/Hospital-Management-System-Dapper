using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Clinic_name { get; set; }
        public string Address { get; set; }
        public string Details { get; set; }
    }
}
