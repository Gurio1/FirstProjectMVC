using AnimeWebSite.Contracts;
using AnimeWebSite.Domain.Common;
using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Identity.Domain.Entities.Users;

namespace AnimeWebSite.Services.Abstractions
{
    public interface IAnimeService : IGenericService<Anime>
    {
        Task<bool> CreateAsync(AddAnimeViewModel viewModel);
        Task<bool> UpdateAsync(UpdateAnimeViewModel animeUpdateVM);
        Task<Anime> GetByIdWithCommentsAsync(int id);
        Task<Anime> GetByIdWithReviewsAsync(int id);
    }
}