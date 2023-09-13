using DrinkingBuddies.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinkingBuddies.Domain
{
    public class DrinkingBuddiesContext : DbContext
    {
        public DrinkingBuddiesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }

    }
}
