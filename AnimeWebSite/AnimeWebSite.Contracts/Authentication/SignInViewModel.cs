using System.ComponentModel.DataAnnotations;

namespace AnimeWebSite.Contracts
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
