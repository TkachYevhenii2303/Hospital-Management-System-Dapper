using Data_Access_Layer_EF.Base_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    internal class Appointment : Entity
    {
        public Guid Patient_Case_Id { get; set; }

        public Guid In_Department_Id { get; set; }

        public DateTime Appointment_Start_time { get; set; }

        public DateTime Appointment_End_time { get; set; }

        public Guid Appointment_Status_Id { get; set; }
    }
}
