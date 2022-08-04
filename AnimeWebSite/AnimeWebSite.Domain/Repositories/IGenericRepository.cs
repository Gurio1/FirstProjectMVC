using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Domain.Repositories
{
    public interface IGenericRepository<T>  where T:class
    {
        Task AddAsync(T entity);
        void Update(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        void Delete(T entity);

    }
}
