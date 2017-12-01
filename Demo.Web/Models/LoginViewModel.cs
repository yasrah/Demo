using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.Web.Models
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Feltet {0} er påkrevd!")]
        [DisplayName("Epost")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Passord")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Feltet {0} er påkrevd!")]
        public string Password { get; set; }

        [DisplayName("Husk meg!")]
        public bool RememberMe { get; set; }

        public string RedirectUrl { get; set; }
    }
}