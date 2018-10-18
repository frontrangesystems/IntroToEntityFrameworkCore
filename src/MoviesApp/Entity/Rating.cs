using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Entity
{
    [Table(nameof(Rating))]
    public partial class Rating
    {
        public Rating()
        {
            Films = new HashSet<Film>();
        }

        public int RatingId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<Film> Films { get; set; }
    }
}
