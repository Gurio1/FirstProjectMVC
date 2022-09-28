using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Domain.Repositories;
using AnimeWebSite.Identity.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Services.Abstractions
{
    public interface IAnimeReviewsService : IGenericService<AnimeReviews>
    {
        Task<bool> CreateAsync(int animeId, int userId, string comment);
    }
}
