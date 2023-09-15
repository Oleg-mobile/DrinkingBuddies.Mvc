using DrinkingBuddies.Mvc.Services.Accounts;
using DrinkingBuddies.Mvc.Services.Accounts.Dto;
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

        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string login, string password, string description, bool isAdmin)
        {
            var isExist = await _accountService.CheckForExistAsync(login);
            var count = await _accountService.GetElementCountAsync();

            if (count < 3)
            {
                if (!isExist)
                {
                    AddDto addDto = new AddDto
                    {
                        Name = login,
                        Password = password,
                        Description = description,
                        IsAdmin = isAdmin
                    };

                    await _accountService.AddAsync(addDto);
                }
            }

            return View();
        }
    }
}
