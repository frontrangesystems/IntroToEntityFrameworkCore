using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;

namespace MoviesApp.Helpers
{
    public static class PerformanceHelper
    {
        public static void RunAll()
        {
            PoorlyPerformingQuery();
            OptimizedQuery();
        }

        private static void PoorlyPerformingQuery()
        {
            ConsoleHelper.WriteCaller();

            var count = 0;
            var films = MoviesContext.Instance.Films;
            count++;
            foreach (var film in films)
            {
                MoviesContext.Instance.Entry(film).Collection(f => f.FilmActors).Load();
                count++;
                foreach (var filmActor in film.FilmActors)
                {
                    MoviesContext.Instance.Entry(filmActor).Reference(fa => fa.Actor).Load();
                    count++;
                }
            }
            Console.WriteLine($"total queries: {count}");
        }

        private static void OptimizedQuery()
        {
            ConsoleHelper.WriteCaller();

            var films = MoviesContext.Instance.Films
                .Include(f => f.FilmActors)
                .ThenInclude(fa => fa.Actor)
                .ToList();
            foreach (var film in films)
            {
                foreach (var filmActor in film.FilmActors)
                {
                    // do nothing
                }
            }

            Console.WriteLine("Only one query executed.");
        }
    }
}