using AnimeWebSite.Domain.Entities;
namespace AnimeWebSite.Domain.Repositories
{
    public interface IAnimeRepository : IGenericRepository<Anime>
    {
        public Task<Anime> GetByIdWithCommentsAsync(int id);
    }
}
