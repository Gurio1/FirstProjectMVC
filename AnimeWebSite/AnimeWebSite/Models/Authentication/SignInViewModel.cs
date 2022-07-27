using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Domain.Authentication
{
    public class SignInViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
