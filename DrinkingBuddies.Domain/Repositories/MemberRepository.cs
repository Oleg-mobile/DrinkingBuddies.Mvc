﻿using DrinkingBuddies.Domain.Common;
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
                throw new EntityNotFoundException(id);
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Member>> GetAsync() =>
            await _context.Members.ToListAsync();

        public async Task<Member> GetByIdAsync(int id) =>
            await _context.Members.FindAsync(id);

        public async Task<Member> GetByNameAsync(string login) => 
            await _context.Members.FirstOrDefaultAsync(member => member.Name == login.Trim());

        public async Task<int> GetNumberAsync() => 
            await _context.Members.CountAsync();

        public async Task<bool> IsAdminAsync() =>
            await _context.Members.AnyAsync(member => member.IsAdmin == true);
    }
}
