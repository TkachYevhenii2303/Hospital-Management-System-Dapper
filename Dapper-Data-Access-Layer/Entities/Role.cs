using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper_Data_Access_Layer.Base_Entity;

namespace Dapper_Data_Access_Layer.Entities
{
    [Table("Role")]
    public class Role : Entity
    {
        public string Role_name { get; set; } = String.Empty;
    }
}
