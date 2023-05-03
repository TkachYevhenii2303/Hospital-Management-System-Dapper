using Dapper_Data_Access_Layer.Base_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Appointment : Entity
    {
        public DateTime Appointment_Start_time { get; set; }

        public DateTime Appointment_End_time { get; set; }
        
        public Guid Patient_Cases_ID { get; set; }

        public Guid In_Departments_ID { get; set; }
    }
}
