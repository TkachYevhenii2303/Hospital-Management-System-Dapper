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
    public class Hospital : Entity
    {
        public string Hospital_title { get; set; } = string.Empty;
        
        public string Address { get; set; } = string.Empty;
        
        public string Details { get; set; } = string.Empty; 
    }
}
