using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
   public class Cycles
    {
        [Key]
        public Int64 idcycle { get; set; }
        [Required]
        public Int32 state { get; set; }
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
    }
}
