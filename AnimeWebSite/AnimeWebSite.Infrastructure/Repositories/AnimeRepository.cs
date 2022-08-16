using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Domain.Exceptions;
using AnimeWebSite.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AnimeWebSite.Infrastructure.Repositories
{
    public sealed class AnimeRepository : GenericRepository<Anime>, IAnimeRepository
    {
        public AnimeRepository(AnimeWebSiteDbContext dbContext) : base(dbContext)
        {

        }
    }
}
