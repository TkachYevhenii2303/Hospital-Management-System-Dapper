using Dapper_Data_Access_Layer.Base_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Documents : Entity
    {
        public string Document_Internal_id { get; set; } = String.Empty;

        public string Document_Name { get; set; } = String.Empty;

        public string Document_link { get; set; } = String.Empty;

        public string Document_Details { get; set; } = String.Empty;
        
        public Guid Document_type_Id { get; set; }

        public Guid Patients_Id { get; set; }
        
        public Guid Patient_Case_Id { get; set; }
        
        public Guid In_Department_Id { get; set; }

        public Guid Appointment_Status_Id { get; set; }
    }
}
