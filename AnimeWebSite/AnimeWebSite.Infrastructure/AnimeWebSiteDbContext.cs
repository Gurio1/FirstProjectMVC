using AnimeWebSite.Domain1.Common;
using Microsoft.EntityFrameworkCore;

namespace AnimeWebSiteInfrastructure
{
    public class AnimeWebSiteDbContext : DbContext
    {
        public AnimeWebSiteDbContext(DbContextOptions<AnimeWebSiteDbContext> options) : base(options) { }

        public DbSet<Anime> Animes { get; set; }
    }
}