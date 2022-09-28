using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Identity.Domain.Entities.Users;
using AnimeWebSite.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnimeWebSite.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AnimeController(IServiceManager serviceManager, UserManager<ApplicationUser> userManager,
                               IMapper mapper)
        {
            _serviceManager = serviceManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet("[controller]/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var anime = await _serviceManager.AnimeService.GetByIdWithReviewsAsync(id);
            if (anime is null)
            {
                return NotFound(anime);
            }

            return View(anime);
        }

        [HttpGet("[controller]/Watching/{id}")]
        public async Task<IActionResult> Watching(int id)
        {
            var anime = await _serviceManager.AnimeService.GetByIdWithCommentsAsync(id);
            if (anime is null)
            {
                return NotFound(anime);
            }

            return View(anime);
        }

        [Authorize]
        [HttpGet("[controller]/make-comment/{id}")]
        public async Task<IActionResult> Comment([FromQuery]int animeId, string comment)
        {
            var user = await _userManager.GetUserAsync(User);

            await _serviceManager.CommentsService.CreateAsync(animeId, user.Id,comment);

            return Ok();
        }


        [Authorize]
        public async void Review(int animeId, string review)
        {
            var user = await _userManager.GetUserAsync(User);

            await _serviceManager.ReviewsService.CreateAsync(animeId, user.Id, review);

        }
    }
}
