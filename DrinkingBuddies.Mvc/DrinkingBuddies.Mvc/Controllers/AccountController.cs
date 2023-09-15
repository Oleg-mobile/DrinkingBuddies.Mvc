using DrinkingBuddies.Mvc.Services.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace DrinkingBuddies.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }

            var member = await _accountService.GetMemberAsync(login, password);

            if (member is not null)
            {
                return RedirectToAction("Get", "Members");
            }
            else
            {
                return View();
            }
        }
    }
}
