using AnimeWebSite.Domain.Repositories;
using AnimeWebSite.Infrastructure.Repository;
using AnimeWebSite.Services.Abstractions;
using AutoMapper;

namespace AnimeWebSite.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAnimeService> _lazyAnimeService;

        public ServiceManager(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _lazyAnimeService = new Lazy<IAnimeService>(() => new AnimeService(repositoryManager, mapper));
        }

        public IAnimeService AnimeService => _lazyAnimeService.Value;
    }
}
