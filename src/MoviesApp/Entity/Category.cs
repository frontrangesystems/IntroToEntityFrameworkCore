using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Entity
{
    [Table(nameof(Category))]
    public partial class Category
    {
        public Category()
        {
            FilmCategories = new HashSet<FilmCategory>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<FilmCategory> FilmCategories { get; set; }
    }
}
