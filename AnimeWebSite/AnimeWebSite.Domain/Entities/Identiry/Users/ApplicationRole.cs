using Microsoft.AspNetCore.Identity;

namespace AnimeWebSite.Identity.Domain.Entities.Users
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ICollection<ApplicationUser> Users { get; set; } = default!;
    }
}
