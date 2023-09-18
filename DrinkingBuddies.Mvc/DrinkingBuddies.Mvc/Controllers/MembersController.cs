using DrinkingBuddies.Mvc.Services.Members;
using Microsoft.AspNetCore.Mvc;

namespace DrinkingBuddies.Mvc.Controllers
{
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
            await _service.DeleteAsync(id);
            return RedirectToAction("Get", "Members");
        }
    }
}
