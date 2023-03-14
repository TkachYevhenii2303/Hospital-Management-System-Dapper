using Data_Access_Layer_EF.Base_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    internal class Status_History : Entity 
    {
        public Guid Appointment_Id { get; set; }

        public Guid Appointment_Status_Id { get; set; }

        public DateTime Status_time { get; set; }

        public string Details { get; set; } = String.Empty;
    }
}
