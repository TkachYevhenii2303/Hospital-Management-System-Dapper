using Data_Access_Layer_EF.Base_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    public class Roles : Entity
    {
        [Required]
        public string Role_name { get; set; } = String.Empty;

        public ICollection<Employees> Employees { get; set; }   
    }
}
