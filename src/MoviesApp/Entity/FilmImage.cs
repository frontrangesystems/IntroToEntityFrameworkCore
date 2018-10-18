using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Entity
{
    [Table(nameof(FilmImage))]
    public partial class FilmImage
    {
        public int FilmImageId { get; set; }
        public int FilmId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }

        public Film Film { get; set; }
    }
}
