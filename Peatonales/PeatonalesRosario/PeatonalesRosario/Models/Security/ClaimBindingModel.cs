﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Servicio.Models.Security
{
    public class ClaimBindingModel
    {
        [Required]
        [Display(Name = "Claim Type")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Claim Value")]
        public string Value { get; set; }
    }
}