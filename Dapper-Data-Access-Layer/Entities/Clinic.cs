using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    [Table("Clinic")]
    public class Clinic
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Clinic's name is required!")]
        [StringLength(100, ErrorMessage = "Clinic's name can't be longer than 100 characters!")]
        public string Clinic_name { get; set; }
        [Required(ErrorMessage = "Address is required!")]
        [StringLength(100, ErrorMessage = "Address's name can't be longer than 100 characters!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Details is required!")]
        [StringLength(100, ErrorMessage = "Details name can't be longer than 100 characters!")]
        public string Details { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}
