using Microsoft.EntityFrameworkCore;
using MoviesApp.Entity;

namespace MoviesApp.Data
{
    public class MoviesContext : DbContext
    {
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<FilmActor> FilmActors { get; set; }
        public virtual DbSet<FilmCategory> FilmCategories { get; set; }
        public virtual DbSet<FilmImage> FilmImages { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        private static MoviesContext _instance;

        public static MoviesContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MoviesContext();
                }

                return _instance;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Movies;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasIndex(e => e.RatingId);

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.RatingId);
            });

            modelBuilder.Entity<FilmActor>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.ActorId });

                entity.HasIndex(e => e.ActorId);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.FilmActors)
                    .HasForeignKey(d => d.ActorId);

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmActors)
                    .HasForeignKey(d => d.FilmId);
            });

            modelBuilder.Entity<FilmCategory>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.CategoryId });

                entity.HasIndex(e => e.CategoryId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.FilmCategories)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmCategories)
                    .HasForeignKey(d => d.FilmId);
            });

            modelBuilder.Entity<FilmImage>(entity =>
            {
                entity.HasIndex(e => e.FilmId)
                    .IsUnique();

                entity.HasOne(d => d.Film)
                    .WithOne(p => p.FilmImage)
                    .HasForeignKey<FilmImage>(d => d.FilmId);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Code).IsRequired();
            });
        }
    }
}
