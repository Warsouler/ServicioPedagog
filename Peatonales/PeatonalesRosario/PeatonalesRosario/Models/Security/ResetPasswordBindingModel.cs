using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Servicio.Models.Security
{
    public class ResetPasswordBindingModel
    {
       
        public long idresetpassword {get;set;}
        [Required]
        public string token {get;set;}
        public int state {get;set;}
        public DateTime expiredate {get;set;}
        [Required]
        public string email {get;set;}

        [Required]
        public string newpassword { get; set; }
    }
}