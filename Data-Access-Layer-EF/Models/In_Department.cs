using Data_Access_Layer_EF.Base_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    internal class In_Department : Entity
    {
        public Guid Employees_Id { get; set; }

        public Guid Department_Id { get; set; }
        
        public DateTime Time_from { get; set; }
        
        public DateTime Time_to { get; set;}
        
        public bool Active_is { get; set; }
    }
}
