using Dapper_Data_Access_Layer.Base_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Status_Histories : Entity
    {
        public string Details { get; set; } = string.Empty;
        
        public Guid Appointment_ID { get; set; }

        public Guid Appointment_Status_ID { get; set; }
    }
}
