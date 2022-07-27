using AnimeWebSite.Domain.Entities;

namespace AnimeWebSite.Domain.Repositories
{
    public interface IAnimeRepository
    {
        Task<IEnumerable<Anime>> GetAllAnimesAsync();
        Task<Anime> GetAnimeByIdAsync(int id);
        void Add(Anime anime);
        void Update(Anime anime);
        Task Delete(int id);
        void Delete(Anime anime);
    }
}
