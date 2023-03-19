using Data_Access_Layer_EF.Base_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    internal class Apointment_Status : Entity 
    {
        [Required(ErrorMessage = "Name is required")]
        public string Status_name { get; set; }
    }
}
