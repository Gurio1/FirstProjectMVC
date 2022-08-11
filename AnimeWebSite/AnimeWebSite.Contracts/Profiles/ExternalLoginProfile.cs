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
                           opt => opt.MapFrom(src => src.Principal.FindFirstValue(ClaimTypes.GivenName)))
                .ForMember(dest => dest.Email,
                           opt => opt.MapFrom(src => src.Principal.FindFirstValue(ClaimTypes.Email)))
                .AfterMap((_, dest) =>
                {
                    dest.RegistrationDate = DateTime.Now;
                });
        }

    }
}
