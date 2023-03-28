using Data_Access_Layer_EF.Base_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    public class Patients_Case : Entity 
    {
        public DateTime Start_time { get; set; }
        
        public DateTime End_time { get; set;}
        
        public bool In_Progress { get; set; }

        public decimal Total_Cost { get; set; }

        public decimal Amound_Paid { get; set; }

        public Patients Patients { get; set; }

        public ICollection<Appointment> Appointments { get; set; }  

        public ICollection<Documents> Documents { get; set; }
    }
}
