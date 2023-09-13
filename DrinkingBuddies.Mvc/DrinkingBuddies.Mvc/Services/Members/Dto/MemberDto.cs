using AutoMapper;
using DrinkingBuddies.Domain.Models;

namespace DrinkingBuddies.Mvc.Services.Members.Dto
{
    [AutoMap(typeof(Member), ReverseMap = true)]
    public class MemberDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsAdmin { get; set; }
    }
}
