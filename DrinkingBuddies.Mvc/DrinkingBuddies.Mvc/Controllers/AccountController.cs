using DrinkingBuddies.Mvc.Services;
using DrinkingBuddies.Mvc.Services.Accounts;
using DrinkingBuddies.Mvc.Services.Accounts.Dto;
using DrinkingBuddies.Mvc.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var member = await _accountService.GetMemberAsync(model.Login);

                if (member is not null)
                {
                    if (!member.IsAdmin)
                    {
                        ModelState.AddModelError(string.Empty, "Вход только для администраторов");
                        return View(model);
                    }

                    if (member.Password.Equals(PasswordEncryption.EncodePassword(model.Password, member.Salt)))
                    {
                        await Authenticate(model.Login);
                        return RedirectToAction("Get", "Members");
                    }
                }
                ModelState.AddModelError(string.Empty, "Не правильно введён логин и/или пароль");
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var member = await _accountService.GetMemberAsync(model.Login);

                if (member is null)
                {
                    var count = await _accountService.GetNumberAsync();

                    if (count >= 3)
                    {
                        ModelState.AddModelError(string.Empty, "Компания уже собралась");
                        return View(model);
                    }

                    var isAdmin = await _accountService.IsAdminAsync();

                    if (isAdmin && model.IsAdmin)
                    {
                        ModelState.AddModelError(string.Empty, "Админ уже есть");
                        return View(model);
                    }

                    var salt = PasswordEncryption.GenerateSalt();

                    AddDto addDto = new AddDto
                    {
                        Name = model.Login,
                        Password = PasswordEncryption.EncodePassword(model.Password, salt),
                        Description = model.Description,
                        IsAdmin = model.IsAdmin,
                        Salt = salt
                    };

                    await _accountService.AddAsync(addDto);

                    if (model.IsAdmin)
                    {
                        await Authenticate(model.Login);
                        return RedirectToAction("Get", "Members");
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Вы уже зарегистрированы");
            }

            return View(model);
        }

        private async Task Authenticate(string login)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, login));

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);  // Создаётся cookie для ответа клиенту
        }
    }
}
