using Data_Access_Layer_EF.Base_Model;
using Data_Access_Layer_EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    public class Department : Entity
    {
        [Required]
        public string Department_name { get; set; } = String.Empty;

        public Clinic Clinic { get; set; }

        public ICollection<In_Department> In_Departments { get; set; }
    }
}
