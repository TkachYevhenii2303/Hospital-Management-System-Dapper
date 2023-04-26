using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Base_Entity;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Shedule : Entity
    {
        public Guid In_Department_id { get; set; }

        public DateTime Date { get; set; }
        
        public DateTime Time_start { get; set; }
        
        public DateTime Time_end { get; set; }
    }
}
