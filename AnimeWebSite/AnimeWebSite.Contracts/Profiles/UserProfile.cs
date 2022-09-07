using AnimeWebSite.Contracts.User;
using AnimeWebSite.Domain.Common;
using AnimeWebSite.Identity.Domain.Entities.Users;
using AutoMapper;

namespace AnimeWebSite.Contracts.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SignUpViewModel, ApplicationUser>()
                .ForMember(dest => dest.Email,
                           opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName,
                           opt => opt.MapFrom(src => src.UserName))
                .AfterMap((_,dest) =>dest.RegistrationDate = DateTime.Now);

            CreateMap<UpdateUserViewModel, ApplicationUser>().ReverseMap();

            CreateMap<UserViewForComment,ApplicationUser>();
        }
    }
}
