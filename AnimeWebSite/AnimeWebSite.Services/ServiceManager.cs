using AnimeWebSite.Domain.Repositories;
using AnimeWebSite.Services.Abstractions;
using AutoMapper;

namespace AnimeWebSite.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAnimeService> _lazyAnimeService;
        private readonly Lazy<ICommentsService> _lazyCommentService;

        public ServiceManager(IAnimeRepository animeRepository,IMapper mapper,
                              ICommentsRepository commentsRepository)
        {
            _lazyAnimeService = new Lazy<IAnimeService>(() => new AnimeService(animeRepository, mapper));
            _lazyCommentService = new Lazy<ICommentsService>(() => new CommentsService(commentsRepository,mapper,animeRepository));
        }

        public IAnimeService AnimeService => _lazyAnimeService.Value;

        public ICommentsService CommentsService => _lazyCommentService.Value;
    }
}
