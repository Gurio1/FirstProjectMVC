using AnimeWebSite.Domain.Common;
using AnimeWebSite.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Infrastructure.Repositories
{
    public class CommentsRepository : GenericRepository<AnimeComment>,ICommentsRepository
    {
        public CommentsRepository(AnimeWebSiteDbContext dbContext) : base(dbContext)
        {

        }
    }
}
