using Data_Access_Layer_EF.Base_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    public class In_Department : Entity
    {
        public DateTime Time_from { get; set; }
        
        public DateTime Time_to { get; set;}
        
        public bool Active_is { get; set; }

        public Employees Employees { get; set; }

        public Department Department { get; set; }

        public ICollection<Shedule> Shedules { get; set; }  

        public ICollection<Appointment> Appointments { get; set; }

        public ICollection<Documents> Documents { get; set; }
    }
}
