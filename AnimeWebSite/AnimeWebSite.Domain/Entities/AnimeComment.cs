using AnimeWebSite.Identity.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeWebSite.Domain.Entities
{
    public class AnimeComment : BaseEntity
    {
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int AnimeId { get; set; }

        public Anime Anime { get; set; }

        public string Content { get; set; }

        public DateTime PostedOn { get; set; }
    }
}
