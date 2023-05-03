using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Base_Entity;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Shedules : Entity
    {
        public DateTime Time_start { get; set; }
        
        public DateTime Time_end { get; set; }

        public Guid In_Departments_ID { get; set; }
    }
}
