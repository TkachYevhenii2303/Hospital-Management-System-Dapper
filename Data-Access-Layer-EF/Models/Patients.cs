using Data_Access_Layer_EF.Base_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    public class Patients : Entity
    {
        public string First_name { get; set; } = String.Empty;
        
        public string Last_name { get; set; } = String.Empty;

        public ICollection<Patients_Case> Patients_Cases { get; set; }

        public ICollection<Documents> Documents { get; set; }
    }
}
