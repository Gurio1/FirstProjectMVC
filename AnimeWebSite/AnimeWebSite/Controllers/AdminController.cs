using AnimeWebSite.Contracts;
using AnimeWebSite.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeWebSite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IServiceManager _serviceManager;
        
        private readonly IWebHostEnvironment _appEnvironment;

        public AdminController(IServiceManager serviceManager, IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            _serviceManager = serviceManager;
        }
        public IActionResult AddAnime()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnime(AddAnimeViewModel anime)
        {
            if (anime is null)
            {
                return View(anime);
            }
             anime.ImagePath = getPath(anime.Image);

            _serviceManager.AnimeService.CreateAsync(anime);

            return Redirect("/");
        }

        public string getPath(IFormFile uploadedFile)
        {
            var path = string.Empty;
            if (uploadedFile != null)
            {

                path = "/Files/" + uploadedFile.FileName;

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }
            }
            return path;
        }
        public IActionResult Admin()
        {
            ViewBag.Name = User.Identity.Name;
            return View();
        }
    }
}
