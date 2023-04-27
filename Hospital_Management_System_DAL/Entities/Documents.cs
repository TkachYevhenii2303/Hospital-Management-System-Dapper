using Dapper_Data_Access_Layer.Base_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Documents : Entity
    {
        public string Documents_title { get; set; } = string.Empty;

        public string Documents_link { get; set; } = string.Empty;

        public string Documents_details { get; set; } = string.Empty;
        
        public Guid Documents_types_ID { get; set; }

        public Guid Patients_ID { get; set; }
        
        public Guid Patient_Cases_ID { get; set; }
        
        public Guid In_Departments_ID { get; set; }

        public Guid Appointment_Status_ID { get; set; }
    }
}
