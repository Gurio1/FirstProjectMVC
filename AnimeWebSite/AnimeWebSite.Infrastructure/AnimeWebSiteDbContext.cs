using AnimeWebSite.Domain.Common;
using AnimeWebSite.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeWebSite.Infrastructure
{
    public class AnimeWebSiteDbContext : DbContext
    {
        public AnimeWebSiteDbContext(DbContextOptions<AnimeWebSiteDbContext> options) : base(options) { }

        public DbSet<Anime> Animes { get; set; }

        public DbSet<TestGenre>Genres { get; set; }
        
        public DbSet<AnimeType>Types { get; set; }
    }
}