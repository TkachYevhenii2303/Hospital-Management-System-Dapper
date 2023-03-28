using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Base_Entity;

namespace Dapper_Data_Access_Layer.Entities
{
    [Table("Shedule")]
    public class Shedule : Entity
    {
        public int In_Department_id { get; set; }

        public DateOnly Date { get; set; }
        
        public TimeOnly Time_start { get; set; }
        
        public TimeOnly Time_end { get; set; }
    }
}
