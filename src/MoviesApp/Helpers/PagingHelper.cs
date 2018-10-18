using System;
using System.Linq;
using ConsoleTables;
using MoviesApp.Data;
using MoviesApp.Entity;
using MoviesApp.Extensions;
using MoviesApp.Models;

namespace MoviesApp.Helpers
{
    public static class PagingHelper
    {
        public static void RunAll(){
            PagedFilms();
            PagedActors();
        }
        private static void PagedFilms()
        {
            ConsoleHelper.WriteCaller();

            var films = MoviesContext.Instance.Films.OrderBy(f => f.Title)
                .Select(f => f.Copy<Film, FilmModel>());

            ConsoleTable.From(films).Write();

            Console.WriteLine("Enter the page size:");
            var pageSize = Console.ReadLine().ToInt();

            Console.WriteLine("Enter the page number:");
            var pageNumber = Console.ReadLine().ToInt();

            var skip = pageSize * (pageNumber - 1);
            films = MoviesContext.Instance.Films
                .OrderBy(f => f.Title)
                .Skip(skip)
                .Take(pageSize)
                .Select(f => f.Copy<Film, FilmModel>());

            ConsoleTable.From(films).Write();
        }

        private static void PagedActors()
        {
            ConsoleHelper.WriteCaller();

            var actors = MoviesContext.Instance.Actors
                .OrderBy(a => a.LastName).ThenBy(a => a.FirstName)
                .Select(a => a.Copy<Actor, ActorModel>());
            ConsoleTable.From(actors).Write();

            Console.WriteLine("Enter the page size:");
            var pageSize = Console.ReadLine().ToInt();

            Console.WriteLine("Enter the page number:");
            var pageNumber = Console.ReadLine().ToInt();

            var skip = pageSize * (pageNumber - 1);
            actors = MoviesContext.Instance.Actors
                .OrderBy(a=>a.LastName).ThenBy(a=>a.FirstName)
                .Skip(skip)
                .Take(pageSize)
                .Select(a => a.Copy<Actor, ActorModel>());

            ConsoleTable.From(actors).Write();
        }

    }
}