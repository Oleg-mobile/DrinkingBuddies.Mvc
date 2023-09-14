namespace DrinkingBuddies.Domain.Models
{
    public class Member : Entity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Description { get; set; }
        public bool IsAdmin { get; set; }
    }
}
