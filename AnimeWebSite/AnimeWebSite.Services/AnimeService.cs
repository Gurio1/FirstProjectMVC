using AnimeWebSite.Contracts;
using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Domain.Repositories;
using AnimeWebSite.Services.Abstractions;
using AutoMapper;

namespace AnimeWebSite.Services
{
    public sealed class AnimeService : GenericService<IAnimeRepository,Anime>, IAnimeService
    {
        private readonly IMapper _mapper;
        private readonly IAnimeRepository _animeRepository;

        public AnimeService(IAnimeRepository animeRepository, IMapper mapper) : base(animeRepository)
        {
            _mapper = mapper;
            _animeRepository = animeRepository;
        }

        public async Task<bool> CreateAsync(AddAnimeViewModel viewModel)
        {

            var anime = _mapper.Map<Anime>(viewModel);

            await base.CreateAsync(anime);

            return true;       
        }

        public async Task<Anime> GetByIdWithCommentsAsync(int id)
        {
            return await _animeRepository.GetByIdWithCommentsAsync(id);
        }

        public async Task<Anime> GetByIdWithReviewsAsync(int id)
        {
            return await _animeRepository.GetByIdWithReviewsAsync(id);
        }

        public async Task<bool> UpdateAsync( UpdateAnimeViewModel animeUpdateVM)
        {
            var anime = _mapper.Map<Anime>(animeUpdateVM);

            await base.UpdateAsync(anime);

            return true;

        }
    }
}