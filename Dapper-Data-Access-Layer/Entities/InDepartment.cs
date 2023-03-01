using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Base_Entity;

namespace Dapper_Data_Access_Layer.Entities
{
    [Table("In_Department")]
    public class InDepartment : Entity
    {
        public int Employees_id { get; set; }
        public int Department_id { get; set; }
        public TimeOnly Time_from { get; set; }
        public TimeOnly Time_to { get; set; }
        public bool Active_is { get; set; }
        public List<Employees> Employees { get; set; } = new List<Employees>();
    }
}
