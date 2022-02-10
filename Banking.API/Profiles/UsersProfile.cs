using AutoMapper;
using Banking.API.Helpers;

namespace Banking.API.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Entities.Users, Models.UsersDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom
                (src => $"{src.Firstname} {src.Lastname} {src.Middlename}"))

                .ForMember(
                dest => dest.Age,
                opt=>opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));

            CreateMap<Models.UsersCreateRepo, Entities.Users>();
            CreateMap<Models.UsersUpdateDto, Entities.Users>();

        }
    }
    
}
