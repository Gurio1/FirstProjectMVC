using AnimeWebSite.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AnimeWebSite.Contracts.Profiles
{
    public class AnimeProfile : Profile
    {
        public AnimeProfile()
        {
            CreateMap<AddAnimeViewModel, Anime>()
                .ForMember(dest => dest.ReleaseDate,
                           opt => opt.MapFrom(src => DateOnly.FromDateTime(src.ReleaseDate)))
                .AfterMap((_, dest) =>
                {
                    dest.PostedOn = DateTime.Now;
                });
            CreateMap<Anime, AnimeDTO>();
        }
    }
}
