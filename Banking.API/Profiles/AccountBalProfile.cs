using AutoMapper;

namespace Banking.API.Profiles
{
    public class AccountBalProfile : Profile
    {
        public AccountBalProfile()
        {
            CreateMap<Entities.AccountBalance, Models.AccountBalDto>();
                
            CreateMap<Models.AccountBalCreateRepo, Entities.AccountBalance>();
        }
    }
}
