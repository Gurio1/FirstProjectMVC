using AnimeWebSite.Infrastructure;
using AnimeWebSite.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AnimeWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public HomeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var animeList =  await _serviceManager.AnimeService.GetAllAsync();

            return View(animeList);
        }
    }
}
