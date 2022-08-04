﻿using AnimeWebSite.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeWebSite.Domain.Entities
{
    public class Anime
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string OriginalName { get; set; }

        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly ReleaseDate { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        public int Votes { get; set; }

        public float Grade { get; set; }
        [Required]
        public Genre Genres { get; set; }

        public int? Episodes { get; set; }

        public int CurrentEpisodes { get; set; } = 0;

        public string? ImagePath { get; set; }

        public AnimeType Type { get; set; }

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