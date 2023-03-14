using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Select_Repsponse<TEntity>
    {
        public TEntity? Data { get; set; }

        public bool Success { get; set; } = true;;

        public string Message { get; set; } = string.Empty;
    }
}
