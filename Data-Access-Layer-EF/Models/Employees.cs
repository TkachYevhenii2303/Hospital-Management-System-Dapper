using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    public class Employees
    {
        [Required]
        public string First_name { get; set; } = string.Empty;

        [Required]
        public string Last_name { get; set; } = string.Empty;

        [Required]
        public string User_name { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public string? Email { get; set; }
        
        public string? Phone_number { get; set; }
        
        public string? Mobile_number { get; set; }

        [Required]
        public bool Active_is { get; set; }

        public ICollection<Roles> Roles { get; set; }   
    }
}
