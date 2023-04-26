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
        public Guid Patient_Case_Id { get; set; }

        public Guid In_Department_Id { get; set; }
        
        public Guid Appointment_Status_Id { get; set; }

        public DateTime Appointment_Start_time { get; set; }

        public DateTime Appointment_End_time { get; set; }
    }
}
