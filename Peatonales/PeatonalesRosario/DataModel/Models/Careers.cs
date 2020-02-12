using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class Careers
    {
        [Key]
        public Int64 idcareers { get; set; }
        [Required]
        [MaxLength(100)]
        public String name { get; set; }
        [Required]
        public Int32 state { get; set; }
    }
}
