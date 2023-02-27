using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    [Table("Role")]
    public class Role
    {
        public int Id { get; set; }
        public string Role_name { get; set; }
    }
}
