//using Microsoft.EntityFrameworkCore;
//
//namespace MoviesApp.Entity
//{
//    public partial class MoviesAppSqlServerContext : DbContext
//    {
//        public virtual DbSet<Actor> Actor { get; set; }
//        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
//        public virtual DbSet<Category> Category { get; set; }
//        public virtual DbSet<Film> Film { get; set; }
//        public virtual DbSet<FilmActor> FilmActor { get; set; }
//        public virtual DbSet<FilmCategory> FilmCategory { get; set; }
//        public virtual DbSet<FilmImage> FilmImage { get; set; }
//        public virtual DbSet<Rating> Rating { get; set; }
//
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseSqlServer("Server=.;Database=Movies;Trusted_Connection=True;");
//            }
//        }
//
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Film>(entity =>
//            {
//                entity.HasIndex(e => e.RatingId);
//
//                entity.HasOne(d => d.Rating)
//                    .WithMany(p => p.Film)
//                    .HasForeignKey(d => d.RatingId);
//            });
//
//            modelBuilder.Entity<FilmActor>(entity =>
//            {
//                entity.HasKey(e => new { e.FilmId, e.ActorId });
//
//                entity.HasIndex(e => e.ActorId);
//
//                entity.HasOne(d => d.Actor)
//                    .WithMany(p => p.FilmActor)
//                    .HasForeignKey(d => d.ActorId);
//
//                entity.HasOne(d => d.Film)
//                    .WithMany(p => p.FilmActor)
//                    .HasForeignKey(d => d.FilmId);
//            });
//
//            modelBuilder.Entity<FilmCategory>(entity =>
//            {
//                entity.HasKey(e => new { e.FilmId, e.CategoryId });
//
//                entity.HasIndex(e => e.CategoryId);
//
//                entity.HasOne(d => d.Category)
//                    .WithMany(p => p.FilmCategory)
//                    .HasForeignKey(d => d.CategoryId);
//
//                entity.HasOne(d => d.Film)
//                    .WithMany(p => p.FilmCategory)
//                    .HasForeignKey(d => d.FilmId);
//            });
//
//            modelBuilder.Entity<FilmImage>(entity =>
//            {
//                entity.HasIndex(e => e.FilmId)
//                    .IsUnique();
//
//                entity.HasOne(d => d.Film)
//                    .WithOne(p => p.FilmImage)
//                    .HasForeignKey<FilmImage>(d => d.FilmId);
//            });
//
//            modelBuilder.Entity<Rating>(entity =>
//            {
//                entity.Property(e => e.Code).IsRequired();
//            });
//        }
//    }
//}
