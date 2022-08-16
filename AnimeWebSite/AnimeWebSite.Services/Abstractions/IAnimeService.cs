using AnimeWebSite.Contracts;
using AnimeWebSite.Domain.Entities;

namespace AnimeWebSite.Services.Abstractions
{
    public interface IAnimeService : IGenericService<Anime>
    {
        Task<bool> CreateAsync(AddAnimeViewModel viewModel);
        Task<bool> UpdateAsync(UpdateAnimeViewModel animeUpdateVM);
    }
}