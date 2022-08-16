using AnimeWebSite.Infrastructure;
using AnimeWebSite.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AnimeWebSite.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public AnimeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("[controller]/{id}")]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var anime = await _serviceManager.AnimeService.GetByIdAsync(id);
            if (anime is null)
            {
                return NotFound(anime);
            }

            return View(anime);
        }

        [HttpGet("[controller]/Watching")]
        public IActionResult Watching()
        {
            return View();
        }
    }
}
