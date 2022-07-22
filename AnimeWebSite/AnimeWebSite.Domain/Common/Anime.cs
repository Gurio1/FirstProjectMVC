using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeWebSite.Domain1.Common
{
    public class Anime
    {
        [Column("Id")]
        [Required]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Column("CreatedOn")]
        [Required]
        public DateOnly CreatedOn { get; set; }

        [Column("PostedOn")]
        [Required]
        public DateTime PostedOn { get; set; }

        public int Votes { get; set; }

        public float Grade { get; set; }

        [Column("PostedOn")]
        [Required]
        public Genre Genre { get; set; }

        public int? Series { get; set; }

    }
}