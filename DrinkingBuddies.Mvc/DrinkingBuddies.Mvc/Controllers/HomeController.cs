using Microsoft.AspNetCore.Mvc;

namespace DrinkingBuddies.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inter()
        {
            return RedirectToAction("Register", "Account");
        }
    }
}
