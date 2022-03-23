using AutoMapper;

namespace Banking.API.Profiles
{
    public class RegisterUserProfile : Profile
    {
        public RegisterUserProfile()
        {
            CreateMap<Models.RegisterUserCreateRepo, Entities.RegisterUser>();
            CreateMap<Entities.RegisterUser, Models.RegisterUserDto>();
        }
    }
}
