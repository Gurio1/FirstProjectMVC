using AnimeWebSite.Identity.Domain.Entities.Users;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AnimeWebSite.Contracts.Profiles
{
    public class ExternalLoginProfile :Profile
    {
        public ExternalLoginProfile()
        {
            CreateMap<ExternalLoginInfo, ApplicationUser>()
                .ForMember(dest => dest.UserName,
                           opt => opt.MapFrom(src => src.Principal.FindFirstValue(ClaimTypes.Name)))
                .ForMember(dest => dest.Email,
                           opt => opt.MapFrom(src => src.Principal.FindFirstValue(ClaimTypes.Email)))
                .ForMember(dest => dest.ImagePath,
                           opt => opt.MapFrom(src => src.Principal.FindFirstValue(ClaimTypes.UserData)))
                .AfterMap((_, dest) =>
                {
                    dest.RegistrationDate = DateTime.Now;
                    dest.ImagePath = "/Files/DefaultUserImage/DefaultImage.jpg";
                });
        }

    }
}
