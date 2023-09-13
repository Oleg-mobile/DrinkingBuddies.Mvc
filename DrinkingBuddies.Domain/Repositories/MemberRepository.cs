using DrinkingBuddies.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinkingBuddies.Domain.Repositories
{
	public class MemberRepository : IRepository<Member>
	{
		private readonly DrinkingBuddiesContext _context;

		public MemberRepository(DrinkingBuddiesContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Member input)
		{
			await _context.Members.AddAsync(input);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var member = await _context.Members.FindAsync(id);

			if (member is null)
			{
				// exeption
				return;
			}

			_context.Members.Remove(member);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Member>> GetAsync() => await _context.Members.ToListAsync();


		public async Task<IEnumerable<Member>> GetByIdAsync(int id)  // ToDo IQueryable и async
		{
			IQueryable<Member> query = _context.Members;

			query = query.Where(member => member.Id == id);
			var members = await query.ToListAsync();

			return members;
		}
	}
}
