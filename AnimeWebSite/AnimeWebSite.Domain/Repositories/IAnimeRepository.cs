using AnimeWebSite.Domain.Entities;

namespace AnimeWebSite.Domain.Repositories
{
    public interface IAnimeRepository
    {
        Task<IEnumerable<Anime>> GetAllAnimesAsync();
        Task<Anime> GetAnimeByIdAsync(int id);
        Task AddAsync(Anime anime);
        void Update(Anime anime);
        Task DeleteAsync(int id);
        void Delete(Anime anime);
    }
}
