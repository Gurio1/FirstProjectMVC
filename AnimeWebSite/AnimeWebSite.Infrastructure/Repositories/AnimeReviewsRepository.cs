using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Infrastructure.Repositories
{
    public class AnimeReviewsRepository : GenericRepository<AnimeReviews>, IAnimeReviewsRepository
    {
        public AnimeReviewsRepository(AnimeWebSiteDbContext context) : base(context)
        {
        }
    }
}
