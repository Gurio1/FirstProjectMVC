using Microsoft.AspNetCore.Mvc;

namespace AnimeWebSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
