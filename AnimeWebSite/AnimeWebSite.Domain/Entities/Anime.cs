using AnimeWebSite.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeWebSite.Domain.Entities
{
    public class Anime : BaseEntity
    {
        public string Name { get; set; }

        public string OriginalName { get; set; }

        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateOnly ReleaseDate { get; set; }

        public DateTime PostedOn { get; set; }

        public int Votes { get; set; }

        public float Grade { get; set; }

        public Genre Genres { get; set; }

        public int? Episodes { get; set; }

        public int CurrentEpisodes { get; set; } = 0;

        public string ImagePath { get; set; }

        public AnimeType Type { get; set; }

        public ICollection<AnimeComment> Comments { get; set; } = new List<AnimeComment>();

        public enum Genre
        {
            Action,
            Comedy,
            Tragedy,
            Psychological,
            Mecha
        }

    }
}