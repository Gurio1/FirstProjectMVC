using Microsoft.AspNetCore.Identity;

namespace AnimeWebSite.Identity.Domain.Entities.Users
{
    public class ApplicationUser :IdentityUser<int>
    {
        public DateTime RegistrationDate { get; set; }

        public string ImagePath { get; set; } = "/Files/UserImages/UserDefaultImage/DefaultImage.jpg";

    }
}
