using AnimeWebSite.Contracts;
using AnimeWebSite.Services;
using AnimeWebSite.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeWebSite.Controllers
{
    [Authorize(Policy ="Administrator")]
    public class AdminController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IFileSystemService _fIleSystem;

        public AdminController(IServiceManager serviceManager,
                               IFileSystemService fIleSystem)
        {
            _serviceManager = serviceManager;
            _fIleSystem = fIleSystem;
        }
        public IActionResult AddAnime()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimeAsync(AddAnimeViewModel anime)
        {
            if (anime is null)
            {
                return View(anime);
            }
            anime.ImagePath = _fIleSystem.Create(anime.Image, FileSystemService.animeImages,null);

            await _serviceManager.AnimeService.CreateAsync(anime);

            return Redirect("/");
        }

        public IActionResult Admin()
        {
            return View();
        }
    }
}
