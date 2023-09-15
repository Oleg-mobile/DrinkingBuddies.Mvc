using AutoMapper;
using DrinkingBuddies.Domain.Models;

namespace DrinkingBuddies.Mvc.Services.Accounts.Dto
{
    [AutoMap(typeof(Member), ReverseMap = true)]
    public class AccountDto : EntiyDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
