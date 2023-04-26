using Dapper_Data_Access_Layer.Base_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Status_History : Entity
    {
        public Guid Appointment_Id { get; set; }

        public Guid Appointment_Status_Id { get; set; }

        public DateTime Status_time { get; set; }

        public string Details { get; set; } = string.Empty;
    }
}
