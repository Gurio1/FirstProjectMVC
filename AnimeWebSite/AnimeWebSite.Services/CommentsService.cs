using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Services.Abstractions;
using AnimeWebSite.Domain.Repositories;
using AnimeWebSite.Domain.Common;
using AnimeWebSite.Identity.Domain.Entities.Users;
using AutoMapper;

namespace AnimeWebSite.Services
{
    public class CommentsService : GenericService<ICommentsRepository, AnimeComment>, ICommentsService
    {
        private readonly ICommentsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IAnimeRepository _animeRepository;

        public CommentsService(ICommentsRepository repository, IMapper mapper,
                                IAnimeRepository animeRepository) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
            _animeRepository = animeRepository;
        }

        public async Task<bool> CreateAsync(int id, ApplicationUser user, string comment)
        {

            var anime = await _animeRepository.GetByIdAsync(id);

            var animeComment = new AnimeComment
            {
                AnimeId = id,
                User = user,
                Content = comment,
                PostedOn = DateTime.Now,
            };

            var result = await _repository.CreateAsync(animeComment);

            if(result is null)
            {
                return false;
            }

            return true;
        }
    }
}
