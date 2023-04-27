using Dapper_Data_Access_Layer.Base_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Patients_Case : Entity
    {
        public DateTime Start_time { get; set; }

        public DateTime End_time { get; set;}

        public decimal Total_Cost { get; set; } = decimal.Zero;

        public Guid Patients_ID { get; set; }
    }
}
