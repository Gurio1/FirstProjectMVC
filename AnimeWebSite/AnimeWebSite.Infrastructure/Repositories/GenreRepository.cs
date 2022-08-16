using AnimeWebSite.Domain.Common;
using AnimeWebSite.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Infrastructure.Repositories
{
    internal class GenreRepository : GenericRepository<TestGenre>, IGenreRepository
    {
        public GenreRepository(AnimeWebSiteDbContext dbContext) : base(dbContext)
        {
            
        }

    }
}
