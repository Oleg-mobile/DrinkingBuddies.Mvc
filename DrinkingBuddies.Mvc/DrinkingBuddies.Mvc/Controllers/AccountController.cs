using DrinkingBuddies.Mvc.Services;
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

            var member = await _accountService.GetMemberAsync(login);

            if (member is not null && member.Password.Equals(PasswordEncryption.EncodePassword(password, member.Salt)))
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
            var member = await _accountService.GetMemberAsync(login);
            var members = await _accountService.GetAsync();  // TODO или получать количество от репозитория?

            if (members.Count() < 3)
            {
                if (member is null)
                {
                    var salt = PasswordEncryption.GenerateSalt();

                    AddDto addDto = new AddDto
                    {
                        Name = login,
                        //Password = password,
                        Password = PasswordEncryption.EncodePassword(password, salt),
                        Description = description,
                        IsAdmin = isAdmin,
                        Salt = salt
                    };

                    await _accountService.AddAsync(addDto);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
