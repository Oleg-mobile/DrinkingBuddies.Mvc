using DrinkingBuddies.Domain.Models;
using DrinkingBuddies.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DrinkingBuddies.Mvc.Controllers
{
    public class MembersController : Controller
    {
        private readonly IRepository<Member> _repository;

        public MembersController(IRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> GetAsync()
        {
			IEnumerable<Member> members = await _repository.GetAsync();

			return View("Index", members);
        }
    }
}
