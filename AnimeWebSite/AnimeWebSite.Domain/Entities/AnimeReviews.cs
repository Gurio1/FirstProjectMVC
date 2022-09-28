using AnimeWebSite.Identity.Domain.Entities.Users;

namespace AnimeWebSite.Domain.Entities
{
    public class AnimeReviews : BaseEntity
    {
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int AnimeId { get; set; }

        public Anime Anime { get; set; }

        public string Content { get; set; }

        public DateTime PostedOn { get; set; }
    }
}
