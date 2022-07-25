using AnimeWebSite.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AnimeWebSite.Controllers
{
    public class HomeController : Controller
    {
        private AnimeWebSiteDbContext _context;

        public HomeController(AnimeWebSiteDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Animes.ToList());
        }
    }
}
