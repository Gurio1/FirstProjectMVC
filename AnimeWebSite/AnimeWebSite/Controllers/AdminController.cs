using AnimeWebSite.Domain.Common;
using AnimeWebSite.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeWebSite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        AnimeWebSiteDbContext _context;
        IWebHostEnvironment _appEnvironment;

        public AdminController(AnimeWebSiteDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }
        public IActionResult Admin()
        {
            return View(_context.Animes.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/Files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                Anime image = new Anime { Name=uploadedFile.Name, ImagePath = path };
                _context.Animes.Add(image);
                _context.SaveChanges();
            }

            return RedirectToAction("Admin");
        }

        public IActionResult AddAnime()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnime(AddAnimeViewModel anime)
        {
            if(anime is null)
            {
                return View(anime);
            }
            var imagePath = getPath(anime.Image);
            var trueAnime = new Anime {   Name = anime.Name,
                                          OriginalName = anime.OriginalName,
                                          ImagePath = imagePath,
                                          Description = anime.Description,
                                          Genre = anime.AnimeGenre,
                                          ReleaseDate = DateOnly.FromDateTime(anime.ReleaseDate),
                                          Episodes = anime.Episodes,
                                          PostedOn = DateTime.Today
            };
            _context.Animes.Add(trueAnime);
            _context.SaveChanges();

            return Redirect("/AnimeDetails/Details");
        }

        public string getPath(IFormFile uploadedFile)
        {
            var path = string.Empty;
            if (uploadedFile != null)
            {
                // путь к папке Files
                path = "/Files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                     uploadedFile.CopyTo(fileStream);
                }
            }
            return path;
        }
        //public IActionResult Admin()
        //{
        //    ViewBag.Name = User.Identity.Name;
        //    return View();
        //}
    }
}
