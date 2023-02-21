using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Shedule
    {
        public int Id { get; set; }
        public int In_Department_id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time_start { get; set; }
        public TimeOnly Time_end { get; set; }
    }
}
