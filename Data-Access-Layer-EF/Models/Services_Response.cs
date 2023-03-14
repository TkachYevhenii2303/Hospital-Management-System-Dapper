using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    internal class Services_Response<TEntity>
    {
        public TEntity? Entity { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = String.Empty;
    }
}
