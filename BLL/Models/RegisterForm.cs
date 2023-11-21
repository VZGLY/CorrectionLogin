using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class RegisterForm
    {
        [DisplayName("Adresse Email")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [DisplayName("Mot de passe")]
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [DisplayName("Confirmation du mot de passe")]
        [Required]
        [MinLength(8)]
        [Compare("Password")]
        public string ConfirmationPassword { get; set; }

        [DisplayName("Prénom")]
       
        public string Firstname { get; set; }

        [DisplayName("Nom de famille")]
        public string Lastname { get; set; }

    }
}
