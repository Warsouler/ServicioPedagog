using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
   public class HistorialLogin
    {
        [Key]
        public Int64 idhistoriallogin { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        [MaxLength(128)]
        public string Id { get; set; }
    }
}
