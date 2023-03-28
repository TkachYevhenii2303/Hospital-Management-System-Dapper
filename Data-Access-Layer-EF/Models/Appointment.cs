using Data_Access_Layer_EF.Base_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    public class Appointment : Entity
    {
        public DateTime Appointment_Start_time { get; set; }

        public DateTime Appointment_End_time { get; set; }

        public In_Department In_Department { get; set; }

        public Patients_Case Patients_Case { get; set; }

        public ICollection<Documents> Documents { get; set; }

        public ICollection<Apointment_Status> Apointment_Status { get; set; }

    }
}
