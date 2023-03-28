using Data_Access_Layer_EF.Base_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    public class Document_type : Entity
    {
        [Required]
        public string Type_name { get; set; } = String.Empty;

        public ICollection<Documents> Documents { get; set; }
    }
}
