using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Servicio.Models.Security
{
    public class ConfirmRegistrationBindingModel
    {
        [Required]
        public string RandomKey { get; set; }
    }
}