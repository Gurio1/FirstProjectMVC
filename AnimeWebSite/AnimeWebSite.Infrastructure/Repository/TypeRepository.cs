using AnimeWebSite.Domain.Common;
using AnimeWebSite.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Infrastructure.Repository
{
    internal class TypeRepository : IGenericRepository<AnimeType>
    {

        private readonly AnimeWebSiteDbContext _dbContext;

        public TypeRepository(AnimeWebSiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(AnimeType entity)
        {
            await _dbContext.Types.AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var type = await GetByIdAsync(id);

            _dbContext.Types.Remove(type);
        }

        public void Delete(AnimeType entity)
        {
            _dbContext.Types.Remove(entity);
        }

        public async Task<IEnumerable<AnimeType>> GetAllAsync()
        {
           return await _dbContext.Types.ToListAsync();
        }

        public async Task<AnimeType> GetByIdAsync(int id)
        {
            var type = await _dbContext.Types.FirstOrDefaultAsync(t => t.Id.Equals(id));

            return type;
        }

        public void Update(AnimeType entity)
        {
            _dbContext.Types.Update(entity);
        }
    }
}
