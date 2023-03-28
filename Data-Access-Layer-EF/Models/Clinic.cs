using Data_Access_Layer_EF.Base_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    public class Clinic : Entity
    {
        public string Clinic_name { get; set; } = String.Empty;

        public string Address { get; set; } = String.Empty;
        
        public string Details { get; set; } = String.Empty; 

        public ICollection<Department> Departments { get; set; }
    }
}
