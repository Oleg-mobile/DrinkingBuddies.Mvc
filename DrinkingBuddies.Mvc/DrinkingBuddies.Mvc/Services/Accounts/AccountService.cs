using AutoMapper;
using DrinkingBuddies.Domain.Models;
using DrinkingBuddies.Domain.Repositories;
using DrinkingBuddies.Mvc.Services.Accounts.Dto;

namespace DrinkingBuddies.Mvc.Services.Accounts
{
    public class AccountService : MainService, IAccountService
    {
        public AccountService(IRepository<Member> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<AccountDto> GetMemberAsync(string login, string password) =>
            Mapper.Map<AccountDto>(await Repository.GetByAccountAsync(login, password));

        public async Task AddAsync(AddDto addDto)
        {
            await Repository.AddAsync(Mapper.Map<Member>(addDto));
        }

        public async Task<bool> CheckForExistAsync(string key) => 
            await Repository.CheckForExistAsync(key);

        public async Task<int> GetElementCountAsync() =>
            await Repository.GetElementCountAsync();
    }
}
