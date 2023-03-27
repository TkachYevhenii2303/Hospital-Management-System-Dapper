using Dapper_Data_Access_Layer.Base_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Appointment_Status : Entity
    {
        public string Status_Name { get; set; } = String.Empty;
    }
}
