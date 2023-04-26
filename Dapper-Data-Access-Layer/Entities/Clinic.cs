using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Base_Entity;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Clinic : Entity
    {
        public string Clinic_name { get; set; } = String.Empty;
        
        public string Address { get; set; } = String.Empty;
        
        public string Details { get; set; } = String.Empty; 
    }
}
