using Microsoft.AspNetCore.Mvc;

namespace AnimeWebSite.Controllers
{
    public class AnimeDetailsController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}
