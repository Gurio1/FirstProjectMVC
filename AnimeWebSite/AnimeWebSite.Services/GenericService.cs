using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Domain.Repositories;
using AnimeWebSite.Services.Abstractions;

namespace AnimeWebSite.Services
{
    public class GenericService<TRepository, TEntity> : IGenericService<TEntity> where TRepository
                                                        : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IGenericRepository<TEntity> Repository;

        public GenericService(TRepository repository)
        {
            Repository = repository;
        }

        public Task<TEntity> CreateAsync(TEntity entity)
        {
           return  Repository.CreateAsync(entity);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return Repository.DeleteAsync(id);
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Repository.GetAllAsync();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return Repository.GetByIdAsync(id);
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Repository.UpdateAsync(entity);
        }
    }
}
