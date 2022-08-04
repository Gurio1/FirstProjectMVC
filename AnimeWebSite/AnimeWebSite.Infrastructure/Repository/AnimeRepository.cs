﻿using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AnimeWebSite.Infrastructure.Repository
{
    internal sealed class AnimeRepository : IAnimeRepository
    {
        private readonly AnimeWebSiteDbContext _dbContext;

        public AnimeRepository(AnimeWebSiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Anime anime)
        {
             await _dbContext.Animes.AddAsync(anime);
        }

        public async Task DeleteAsync(int id)
        {
            var anime = await GetAnimeByIdAsync(id);

            _dbContext.Animes.Remove(anime);
        }

        public void Delete(Anime anime)
        {
             _dbContext.Animes.Remove(anime);
        }

        public async Task<IEnumerable<Anime>> GetAllAnimesAsync()
        {
            return  await _dbContext.Animes.ToListAsync();
        }

        public async Task<Anime> GetAnimeByIdAsync(int id)
        {
            return await _dbContext.Animes.FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Update(Anime anime)
        {
             _dbContext.Animes.Update(anime);
        }
    }
}
