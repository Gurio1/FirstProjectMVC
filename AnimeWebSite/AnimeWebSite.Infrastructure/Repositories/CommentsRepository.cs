using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Domain.Repositories;

namespace AnimeWebSite.Infrastructure.Repositories
{
    public class CommentsRepository : GenericRepository<AnimeComment>, ICommentsRepository
    {
        public CommentsRepository(AnimeWebSiteDbContext dbContext) : base(dbContext)
        {

        }
    }
}
