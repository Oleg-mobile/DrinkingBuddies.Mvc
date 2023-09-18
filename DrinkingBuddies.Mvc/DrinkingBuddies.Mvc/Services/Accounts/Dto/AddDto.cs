using AutoMapper;
using DrinkingBuddies.Domain.Models;

namespace DrinkingBuddies.Mvc.Services.Accounts.Dto
{
    [AutoMap(typeof(Member), ReverseMap = true)]
    public class AddDto : EntityDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Description { get; set; }
        public bool IsAdmin { get; set; }
        public string Salt { get; set; }
    }
}
