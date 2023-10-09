using Microsoft.AspNetCore.Mvc;

namespace DrinkingBuddies.Mvc.Controllers
{
    public class HomeController : Controller
    {

        [HttpPost]
        public IActionResult Inter()
        {
            return RedirectToAction("Register", "Account");
        }

        public IActionResult Index(string? message)
        {
            ViewBag.Message = message;

            return View();
        }
    }
}
