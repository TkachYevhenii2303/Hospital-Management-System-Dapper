using Dapper_Data_Access_Layer.Base_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Document_type : Entity
    {
        public string Type_name { get; set; } = String.Empty;
    }
}
