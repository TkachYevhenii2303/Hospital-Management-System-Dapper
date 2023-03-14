using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Base_Model
{
    public class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public virtual DateTime? Created_at { get; set; } = DateTime.Now;
        
        public virtual DateTime? Updated_at { get; set; } = DateTime.Now;
    }
}
