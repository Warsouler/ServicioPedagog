using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Servicio.Models.Security
{
    public class UpdateBusinessBindingModel
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
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string OldPassword { get; set; }

        //[Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public long idbusiness { get; set; }

        [Required]
        public int idlocation { get; set; }
        public int state { get; set; }

        [MaxLength(50)]
        public string name { get; set; }

        [MaxLength(50)]
        public string address { get; set; }
        [Required]
        public int addressnumber { get; set; }
        [MaxLength(50)]
        public string floor { get; set; }
        [MaxLength(50)]
        public string floornumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string responsablename { get; set; }

        [Required]
        [MaxLength(20)]
        public string responsablephone { get; set; }

        [Required]
        [MaxLength(20)]
        public string cuitcuilcdi { get; set; }
        public long idtypedocument { get; set; }
        [Required]
        [MaxLength(20)]
        public string businesstype { get; set; }
        public long playeruserid { get; set; }


        public int idconditioniva { get; set; }
        public long idplayeruser { get; set; }


        [MaxLength(50)]
        public string publicname { get; set; }
        [MaxLength(20)]
        public string genre { get; set; }
        public DateTime birthdate { get; set; }
        [MaxLength(100)]
        public string profession { get; set; }
        [MaxLength(500)]
        public string profilephoto { get; set; }
        [MaxLength(20)]
        public string dni { get; set; }
        public int stateplayeruser { get; set; }

        [Required]
        public bool CreatePlayerUser { get; set; }

        [MaxLength(50)]
        public string civilstatus { get; set; }
    }
}