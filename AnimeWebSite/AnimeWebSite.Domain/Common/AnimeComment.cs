using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Identity.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeWebSite.Domain.Common
{
    public class AnimeComment : BaseEntity
    {
        public ApplicationUser User { get; set; }

        public int AnimeId { get; set; }

        public string Content { get; set; } 

        public DateTime PostedOn { get; set; }
    }
}
        