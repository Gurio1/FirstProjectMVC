using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static AnimeWebSite.Domain.Entities.Anime;

namespace AnimeWebSite.Contracts
{
    public class AddAnimeViewModel
    {

        [Required]
        public string Name { get; set; }

        public string OriginalName { get; set; }

        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public Genre Genres { get; set; }

        public int? Episodes { get; set; }

        public int? CurrentEpisodes { get; set; }

        public IFormFile Image { get; set; }

        public string ImagePath { get; set; }
    }
}
