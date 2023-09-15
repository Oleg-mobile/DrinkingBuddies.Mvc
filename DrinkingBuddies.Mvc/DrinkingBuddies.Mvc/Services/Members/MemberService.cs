using AutoMapper;
using DrinkingBuddies.Domain.Models;
using DrinkingBuddies.Domain.Repositories;
using DrinkingBuddies.Mvc.Services.Members.Dto;

namespace DrinkingBuddies.Mvc.Services.Members
{
    public class MemberService : MainService, IMemberService
    {
        public MemberService(IRepository<Member> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<IEnumerable<MemberDto>> GetAsync() =>
            Mapper.Map<IEnumerable<MemberDto>>(await Repository.GetAsync());

        public async Task DeleteAsync(int id) =>
            await Repository.DeleteAsync(id);
    }
}
