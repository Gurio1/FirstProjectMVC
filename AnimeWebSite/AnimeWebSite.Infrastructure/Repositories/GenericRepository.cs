using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AnimeWebSiteDbContext _context;

        public GenericRepository(AnimeWebSiteDbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be created:){ex.Message}");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
           var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));

           if(entity is null)
            {
                throw new Exception($"{nameof(id)} could not be found.");
            }

           _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
               return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

                if (entity is null)
                {
                    throw new Exception($"Could not find entity with id= {id}");
                }

                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception($"Could't retrieve entity with id={id} : {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    }
}
