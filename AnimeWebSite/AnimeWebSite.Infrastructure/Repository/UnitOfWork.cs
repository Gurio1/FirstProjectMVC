using AnimeWebSite.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AnimeWebSiteDbContext _dbContext;
        public UnitOfWork(AnimeWebSiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
