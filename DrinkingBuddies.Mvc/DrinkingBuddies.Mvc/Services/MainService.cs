using AutoMapper;
using DrinkingBuddies.Domain.Models;
using DrinkingBuddies.Domain.Repositories;

namespace DrinkingBuddies.Mvc.Services
{
    public class MainService
    {
        protected IRepository<Member> Repository { get; set; }

        protected IMapper Mapper { get; set; }

        public MainService(IRepository<Member> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
    }
}
