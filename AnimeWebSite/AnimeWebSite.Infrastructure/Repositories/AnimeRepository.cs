using AnimeWebSite.Contracts;
using AnimeWebSite.Domain.Common;
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

        public async Task<Anime> GetByIdWithCommentsAsync(int id)
        {
            try
            {
                var entity = await _context.Animes.Include(c => c.Comments.OrderByDescending(d =>d.PostedOn)).ThenInclude(u =>u.User).Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

                if (entity is null)
                {
                    throw new Exception($"Could not find entity with id= {id}");
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could't retrieve entity with id={id} : {ex.Message}");
            }
        }
    }
}
