using Data_Access_Layer_EF.Base_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    internal class Patients_Case : Entity 
    {
        public Guid Patients_Id { get; set; }
        
        public DateTime Start_time { get; set; }
        
        public DateTime End_time { get; set;}
        
        public bool In_Progress { get; set; }

        public decimal Total_Cost { get; set; }

        public decimal Amound_Paid { get; set; }
    }
}
