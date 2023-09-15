using DrinkingBuddies.Mvc.Services.Accounts.Dto;

namespace DrinkingBuddies.Mvc.Services.Accounts
{
    public interface IAccountService
    {
        Task<AccountDto> GetMemberAsync(string login, string password);
    }
}
