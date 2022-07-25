using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AnimeWebSite.Domain.Common.AddAnimeViewModel;

namespace AnimeWebSite.Domain.Common
{
    public class Anime
    {
        [Column("Id")]
        [Required]
        public int Id { get; set; }

        [Column("Name")]
         [Required]
        public string Name { get; set; }

        public string OriginalName { get; set; }

        public string? Description { get; set; }

        [Column("ReleaseDate")]
        [Required]
        [DataType(DataType.Date)]
        public DateOnly ReleaseDate { get; set; }

        [Column("PostedOn")]
        [Required]
        public DateTime PostedOn { get; set; }

        public int Votes { get; set; }

        public float Grade { get; set; }

        [Column("PostedOn")]
        [Required]
        public Genre Genre { get; set; }

        public int? Episodes { get; set; }

        public int? CurrentEpisodes { get; set; }

        public string ?ImagePath { get; set; }

    }
}