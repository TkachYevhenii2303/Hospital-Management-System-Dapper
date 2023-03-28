using Data_Access_Layer_EF.Base_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    public class Documents : Entity
    {
        [Required]
        public string Document_Name { get; set; } = String.Empty;

        [Required]
        public string Document_link { get; set; } = String.Empty;

        [Required]
        public string Document_Details { get; set; } = String.Empty;

        public Patients_Case Patients_Case { get; set; }    

        public Patients Patients { get; set; }

        public In_Department In_Department { get; set; }

        public Appointment Appointment { get; set; }

        public Document_type Document_Type { get; set; }    
    }
}
