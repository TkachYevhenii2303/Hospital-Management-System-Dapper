using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    [Table("Department")]
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Department's name is required!")]
        [StringLength(100, ErrorMessage = "Department's name can't be longer than 100 characters!")]
        public string Department_name { get; set; }
        public int Clinic_id { get; set; }
    }
}
