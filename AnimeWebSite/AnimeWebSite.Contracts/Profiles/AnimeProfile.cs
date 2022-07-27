using AnimeWebSite.Domain.Entities;
using AutoMapper;

namespace AnimeWebSite.Contracts.Profiles
{
    public class AnimeProfile : Profile
    {
        public AnimeProfile()
        {
            CreateMap<AddAnimeViewModel, Anime>()
                .ForMember(dest => dest.ReleaseDate,
                           opt => opt.MapFrom(src => DateOnly.FromDateTime(src.ReleaseDate)))
                .ForMember(dest =>dest.PostedOn,
                 opt => opt.MapFrom(src => DateTime.Today));
        }
    }
}
