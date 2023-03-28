using Data_Access_Layer_EF.Base_Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Models
{
    public class Shedule : Entity
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime Time_start { get; set; }

        [Required]
        public DateTime Time_end { get; set; }

        public In_Department In_Department { get; set; }
    }
}
