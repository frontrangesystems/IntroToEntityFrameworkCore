using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Entity
{
    [Table(nameof(Film))]
    public partial class Film
    {
        public Film()
        {
            FilmActors = new HashSet<FilmActor>();
            FilmCategories = new HashSet<FilmCategory>();
        }

        public int FilmId { get; set; }
        public string Description { get; set; }
        public string RatingCode { get; set; }
        public int? RatingId { get; set; }
        public int? ReleaseYear { get; set; }
        public int? Runtime { get; set; }
        public string Title { get; set; }

        public Rating Rating { get; set; }
        public FilmImage FilmImage { get; set; }
        public ICollection<FilmActor> FilmActors { get; set; }
        public ICollection<FilmCategory> FilmCategories { get; set; }
    }
}
