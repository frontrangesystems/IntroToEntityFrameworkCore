using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Entity
{
    [Table(nameof(FilmCategory))]
    public partial class FilmCategory
    {
        public int FilmId { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public Film Film { get; set; }
    }
}