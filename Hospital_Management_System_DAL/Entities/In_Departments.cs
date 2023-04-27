using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Base_Entity;

namespace Dapper_Data_Access_Layer.Entities
{
    public class In_Departments : Entity
    {
        
        public DateTime Time_from { get; set; }
        
        public DateTime Time_to { get; set; }

        public bool Active_is { get; set; } = true;

        public Guid Employees_ID { get; set; }

        public Guid Department_ID { get; set; }
    }
}
