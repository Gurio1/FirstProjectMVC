using Microsoft.AspNetCore.Identity;

namespace AnimeWebSite.Identity.Domain.Entities.Users
{
    public class ApplicationUser :IdentityUser<int>
    {
        public DateTime RegistrationDate { get; set; }
       // public int RoleId { get; set; }
       // public bool IsBlocked { get; set; }
        //public ApplicationRole ApplicationRole { get; set; } = default!;


    }
}
