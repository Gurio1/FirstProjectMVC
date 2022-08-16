using Microsoft.AspNetCore.Mvc;

namespace AnimeWebSite.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult UserProfile()
        {

            return View();
        }
    }
}
