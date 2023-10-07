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

        public async Task<AccountDto> GetMemberAsync(string login) =>
            Mapper.Map<AccountDto>(await Repository.GetByNameAsync(login));

        public async Task AddAsync(AddDto addDto)
        {
            await Repository.AddAsync(Mapper.Map<Member>(addDto));
        }

        public async Task<IEnumerable<AccountDto>> GetAsync() =>
            Mapper.Map<IEnumerable<AccountDto>>(await Repository.GetAsync());

        public async Task<bool> IsAdminAsync() =>
            await Repository.IsAdminAsync();
        public async Task<int> GetNumberAsync() =>
            await Repository.GetNumberAsync();
    }
}
