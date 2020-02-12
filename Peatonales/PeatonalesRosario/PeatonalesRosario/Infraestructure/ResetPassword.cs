using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Servicio.Infraestructure
{
    public class ResetPassword
    {
        [Key]
        public Int64 idresetpassword { get; set; }
        [Required]
        [MaxLength(200)]
        public string token { get; set; }
        [Required]
        public int state { get; set; }
        [Required]
        public DateTime expiredate { get; set; }
        [Required]
        [MaxLength(100)]
        public string email { get; set; }
    }
}