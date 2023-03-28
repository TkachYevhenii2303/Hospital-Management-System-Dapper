using Data_Access_Layer_EF.Base_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    public class Apointment_Status : Entity 
    {
        [Required]
        public string Status_name { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
