using DrinkingBuddies.Mvc.Services.Accounts.Dto;

namespace DrinkingBuddies.Mvc.Services.Accounts
{
    public interface IAccountService
    {
        Task<AccountDto> GetMemberAsync(string login);
        Task AddAsync(AddDto addDto);
        Task<IEnumerable<AccountDto>> GetAsync();
        Task<bool> IsAdminAsync();
        Task<int> GetNumberAsync();
    }
}
