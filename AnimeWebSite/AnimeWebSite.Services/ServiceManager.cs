using AnimeWebSite.Domain.Repositories;
using AnimeWebSite.Services.Abstractions;
using AutoMapper;

namespace AnimeWebSite.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAnimeService> _lazyAnimeService;

        public ServiceManager(IAnimeRepository animeRepository,IMapper mapper)
        {
            _lazyAnimeService = new Lazy<IAnimeService>(() => new AnimeService(animeRepository, mapper));
        }

        public IAnimeService AnimeService => _lazyAnimeService.Value;
    }
}
