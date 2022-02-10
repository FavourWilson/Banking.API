using AutoMapper;

namespace Banking.API.Profiles
{
    public class AccountDetailsProfile : Profile
    {
        public AccountDetailsProfile()
        {
            CreateMap<Entities.AccountDetails, Models.AccountDetailsDto>();
            CreateMap<Models.AccountDetailsCreateRepo, Entities.AccountDetails>();
        }
    }
}
