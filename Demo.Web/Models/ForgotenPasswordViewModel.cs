using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.Web.Models
{
    public class ForgotenPasswordViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Feltet {0} er påkrevd!")]
        [DisplayName("Epost")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



        public string RedirectUrl { get; set; }
    }
}