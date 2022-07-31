using AnimeWebSite.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Infrastructure.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IAnimeRepository> _animeRepository;

        private readonly Lazy<IUnitOfWork> _unitOfWork;

        public RepositoryManager(AnimeWebSiteDbContext context)
        {
            _animeRepository = new Lazy<IAnimeRepository>(() => new AnimeRepository(context));

            _unitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
        }
        public IAnimeRepository AnimeRepository => _animeRepository.Value;

        public IUnitOfWork UnitOfWork => _unitOfWork.Value;
    }
}
