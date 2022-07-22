using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeWebSite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            ViewBag.Name = User.Identity.Name;
            return View();
        }
    }
}
