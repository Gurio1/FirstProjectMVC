using AnimeWebSite.Domain.Common;
using AnimeWebSite.Domain.Repositories;

namespace AnimeWebSite.Infrastructure.Repository
{
    public interface IRepositoryManager
    {
        IAnimeRepository AnimeRepository { get; }

        IUnitOfWork UnitOfWork { get; }

        IGenericRepository<AnimeType> TypeRepository { get; }

        IGenericRepository<TestGenre> GenreRepository { get; }
    }
}
