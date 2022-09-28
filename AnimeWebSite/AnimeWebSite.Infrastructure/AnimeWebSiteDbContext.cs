using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Identity.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AnimeWebSite.Infrastructure
{
    public class AnimeWebSiteDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public AnimeWebSiteDbContext(DbContextOptions<AnimeWebSiteDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Anime> Animes { get; set; }     
        public DbSet<AnimeComment> Comments { get; set; }
        public DbSet<TestGenre>Genres { get; set; }   
        public DbSet<AnimeType>Types { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationRole> Roles { get; set; }
    }
}