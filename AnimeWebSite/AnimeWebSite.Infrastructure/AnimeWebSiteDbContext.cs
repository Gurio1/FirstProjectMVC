using AnimeWebSite.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace AnimeWebSite.Infrastructure
{
    public class AnimeWebSiteDbContext : DbContext
    {
        public AnimeWebSiteDbContext(DbContextOptions<AnimeWebSiteDbContext> options) : base(options) { }

        public DbSet<Anime> Animes { get; set; }
    }
}