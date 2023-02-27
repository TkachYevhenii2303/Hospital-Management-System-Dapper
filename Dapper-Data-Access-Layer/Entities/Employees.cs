using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    [Table("Employees")]
    public class Employees
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, ErrorMessage = "First's name can't be longer than 100 characters!")]
        public string First_name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100, ErrorMessage = "Last's name can't be longer than 100 characters!")]
        public string Last_name { get; set; }

        [Required(ErrorMessage = "User name is required")]
        [StringLength(100, ErrorMessage = "User's name can't be longer than 100 characters!")]
        public string User_name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password's name can't be longer than 100 characters!")]
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? Phone_number { get; set; }
        public string? Mobile_number { get; set; }

        [Required(ErrorMessage = "Activity is required")]
        [StringLength(100, ErrorMessage = "Activity's name can't be longer than 100 characters!")]
        public bool Active_is { get; set; }
    }
}
