using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Servicio.Infraestructure
{
    public class ConfirmRegistrations
    {
        [Key]
        public Int64 idregisterconfirm { get; set; }
        [Required]
        [MaxLength(255)]
        public string randomkey { get; set; }
        [Required]
        public Int32 state { get; set; }
        [Required]
        public DateTime dateup { get; set; }
        [Required]
        public DateTime expiredate { get; set; }
        [Required]
        [MaxLength(128)]
        public string Id { get; set; }
        public ApplicationUser AspNetUser;
    }
}