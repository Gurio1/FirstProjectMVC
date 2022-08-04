using AnimeWebSite.Domain.Common;
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

        private readonly Lazy<IGenericRepository<AnimeType>> _typeRepository;

        private readonly Lazy<IGenericRepository<TestGenre>> _genreRepository;

        public RepositoryManager(AnimeWebSiteDbContext context)
        {
            _animeRepository = new Lazy<IAnimeRepository>(() => new AnimeRepository(context));

            _unitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));

            _typeRepository = new Lazy<IGenericRepository<AnimeType>>(() => new TypeRepository(context));

            _genreRepository = new Lazy<IGenericRepository<TestGenre>>(() => new GenreRepository(context));
        }
        public IAnimeRepository AnimeRepository => _animeRepository.Value;

        public IUnitOfWork UnitOfWork => _unitOfWork.Value;

        public IGenericRepository<AnimeType> TypeRepository => throw new NotImplementedException();

        public IGenericRepository<TestGenre> GenreRepository => throw new NotImplementedException();
    }
}
