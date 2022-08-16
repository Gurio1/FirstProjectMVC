using AnimeWebSite.Domain.Common;
using AnimeWebSite.Domain.Repositories;

namespace AnimeWebSite.Infrastructure.Repositories
{
    internal class TypeRepository : GenericRepository<AnimeType>, ITypeRepository
    {

        public TypeRepository(AnimeWebSiteDbContext dbContext) : base(dbContext)
        {
            
        }

    }
}
