using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Domain.Repositories;
using AnimeWebSite.Identity.Domain.Entities.Users;
using AnimeWebSite.Services.Abstractions;

namespace AnimeWebSite.Services
{
    public class AnimeReviewsService : GenericService<IAnimeReviewsRepository, AnimeReviews>, IAnimeReviewsService
    {
        private readonly IAnimeReviewsRepository _repository;

        public AnimeReviewsService(IAnimeReviewsRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(int animeId, int userId, string comment)
        {

            var animeReview = new AnimeReviews
            {
                AnimeId = animeId,
                UserId = userId,
                Content = comment,
                PostedOn = DateTime.Now,
            };

            var result = await _repository.CreateAsync(animeReview);

            if (result is null)
            {
                return false;
            }

            return true;
        }
    }
}
