using AnimeWebSite.Domain.Entities;

namespace AnimeWebSite.Domain.Repositories
{
    public interface IGenericRepository<TEntity>  where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(int id);

    }
}
