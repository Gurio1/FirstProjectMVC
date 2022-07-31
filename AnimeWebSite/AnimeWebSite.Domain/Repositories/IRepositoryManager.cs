using AnimeWebSite.Domain.Repositories;

namespace AnimeWebSite.Infrastructure.Repository
{
    public interface IRepositoryManager
    {
        IAnimeRepository AnimeRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
