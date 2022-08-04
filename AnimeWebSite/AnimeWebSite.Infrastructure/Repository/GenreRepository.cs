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
    internal class GenreRepository : IGenericRepository<TestGenre>
    {
        private readonly AnimeWebSiteDbContext _dbContext;

        public GenreRepository(AnimeWebSiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TestGenre entity)
        {
            await _dbContext.Genres.AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var genre = await GetByIdAsync(id);

            _dbContext.Genres.Remove(genre);
        }

        public void Delete(TestGenre entity)
        {
            _dbContext.Genres.Remove(entity);
        }

        public async Task<IEnumerable<TestGenre>> GetAllAsync()
        {
            return await _dbContext.Genres.ToListAsync();
        }
        public async Task<TestGenre> GetByIdAsync(int id)
        {
            var genre = await _dbContext.Genres.FirstOrDefaultAsync(g => g.Id.Equals(id));

            return genre;
        }

        public void Update(TestGenre entity)
        {
            _dbContext.Genres.Update(entity);
        }
    }
}
