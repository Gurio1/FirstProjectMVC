using AnimeWebSite.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AnimeWebSite.Controllers
{
    public class AnimeDetailsController : Controller
    {
        private AnimeWebSiteDbContext _context;

        public AnimeDetailsController(AnimeWebSiteDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult Details(int? Id)
        {
            var anime = _context.Animes.FirstOrDefault(a => a.Id == Id);
            if(anime is null)
            {
                return NotFound(anime);
            }

            return View(anime);
        }
    }
}
