using AnimeWebSite.Contracts;

namespace AnimeWebSite.Services.Abstractions
{
    public interface IAnimeService
    {
        Task<IEnumerable<AnimeDTO>> GetAllAsync();
        Task<AnimeDTO> GetByIdAsync(int animeId);
        void CreateAsync(AddAnimeViewModel viewModel);
        Task UpdateAsync(UpdateAnimeViewModel animeUpdateVM);
        Task DeleteAsync(int animeId);
    }
}