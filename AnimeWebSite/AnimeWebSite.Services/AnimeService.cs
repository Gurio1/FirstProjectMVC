using AnimeWebSite.Contracts;
using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Domain.Exceptions;
using AnimeWebSite.Infrastructure.Repository;
using AnimeWebSite.Services.Abstractions;
using AutoMapper;

namespace AnimeWebSite.Services
{
    internal sealed class AnimeService : IAnimeService
    {
        private readonly IMapper _mapper;

        private readonly IRepositoryManager _repositoryManager;

        public AnimeService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async void CreateAsync(AddAnimeViewModel viewModel)
        {

            var anime = _mapper.Map<Anime>(viewModel);

            _repositoryManager.AnimeRepository.Add(anime);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int animeId)
        {
             _repositoryManager.AnimeRepository.Delete(animeId);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<AnimeDTO>> GetAllAsync()
        {
            var animes = await _repositoryManager.AnimeRepository.GetAllAnimesAsync();

            var animesDto = _mapper.Map<IEnumerable<AnimeDTO>>(animes);

            return animesDto;
        }

        public async Task<AnimeDTO> GetByIdAsync(int animeId)
        {
            var anime = await _repositoryManager.AnimeRepository.GetAnimeByIdAsync(animeId);

            if (anime is null)
            {
                throw new AnimeNotFoundException(animeId);
            }

            var animeDTO = _mapper.Map<AnimeDTO>(anime);

            return animeDTO;
        }

        public async Task UpdateAsync( UpdateAnimeViewModel animeUpdateVM)
        {
            var anime = _mapper.Map<Anime>(animeUpdateVM);

             _repositoryManager.AnimeRepository.Update(anime);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}