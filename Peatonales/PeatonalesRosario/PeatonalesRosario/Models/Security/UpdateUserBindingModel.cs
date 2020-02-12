using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Servicio.Models.Security
{
    public class UpdateUserBindingModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        [MaxLength(20, ErrorMessage = "El nombre de usuario no puede contener más de 20 carácteres")]
        [RegularExpression("^([a-zA-Z0-9])+[a-zA-Z0-9]+$", ErrorMessage = "Solo puede contener números y letras")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

       

        //[Required]
        //[Display(Name = "Role Name")]
        //public string RoleName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string OldPassword { get; set; }


        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        

      
        //[Required]
        public int state { get; set; }
        //[Required]
        //public int age { get; set; }
        
    }
}