using DrinkingBuddies.Mvc.Services.Members;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrinkingBuddies.Mvc.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        private readonly IMemberService _service;

        public MembersController(IMemberService service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetAsync() =>
            View("Index", await _service.GetAsync());

        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return RedirectToAction("Get", "Members");
            }
            catch (Exception ex)
            {
                //  редирект на страницу с сообщением об ошибке
                return RedirectToAction("Index", "Home", new { message = $"Ошибка: {ex.Message} "});
            }
        }
    }
}
