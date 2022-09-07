using AnimeWebSite.Domain.Common;
using AnimeWebSite.Identity.Domain.Entities.Users;
using AnimeWebSite.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

            var anime = await _serviceManager.AnimeService.GetByIdAsync(id);
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
        public async Task<IActionResult> Comment(int id, string comment)
        {
            var user = await _userManager.GetUserAsync(User);

            await _serviceManager.CommentsService.CreateAsync(id,user,comment);

            return RedirectToAction(nameof(Watching), new {id = id});
        }
    }
}
