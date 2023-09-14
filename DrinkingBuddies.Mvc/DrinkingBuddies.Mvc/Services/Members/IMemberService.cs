using DrinkingBuddies.Mvc.Services.Members.Dto;

namespace DrinkingBuddies.Mvc.Services.Members
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberDto>> GetAsync();
    }
}
