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
            // TODO проверка на контроллере

            await _context.Members.AddAsync(input);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member is null)
            {
                // TODO exeption
                return;
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Member>> GetAsync() => 
            await _context.Members.ToListAsync();


        public async Task<Member> GetByIdAsync(int id) =>
            await _context.Members.FindAsync(id);

        public async Task<Member> GetByAccountAsync(string login, string password) => 
            await _context.Members.FirstAsync(member => member.Name == login.Trim() && member.Password == password);

        public async Task<bool> CheckForExistAsync(string key) => 
            await _context.Members.AnyAsync(m => m.Name == key.Trim());

        public async Task<int> GetElementCountAsync() => 
            await _context.Members.CountAsync();
    }
}
