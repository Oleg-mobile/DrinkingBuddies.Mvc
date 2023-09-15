using AutoMapper;
using DrinkingBuddies.Domain.Models;

namespace DrinkingBuddies.Mvc.Services.Members.Dto
{
    [AutoMap(typeof(Member), ReverseMap = true)]
    public class MemberDto : EntityDto
    {
        public string Name { get; set; }
    }
}
