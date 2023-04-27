using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Base_Entity
{
    public abstract class Entity
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public virtual DateTime Created_at { get; set; } = DateTime.Now;
        
        public virtual DateTime Updated_at { get; set; } = DateTime.Now;
    }
}
