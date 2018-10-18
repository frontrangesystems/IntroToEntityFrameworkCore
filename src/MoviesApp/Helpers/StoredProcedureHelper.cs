using System;
using System.Linq;
using ConsoleTables;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Entity;
using MoviesApp.Extensions;
using MoviesApp.Models;

namespace MoviesApp.Helpers
{
    public static class StoredProcedureHelper
    {
        public static void RunAll()
        {
            FindFilms();
            FindActors();
            PagedActors();
        }

        private static void FindFilms()
        {
            ConsoleHelper.WriteCaller();

            var sql = "FilmStartsWith {0}";
            var films = MoviesContext.Instance.Films
                .FromSql(sql, "t")
                .Select(f => ObjectExtensions.Copy<Film, FilmModel>(f));
            ConsoleTable.From(films).Write();
        }

        private static void FindActors()
        {
            ConsoleHelper.WriteCaller();

            var sql = "FindActor {0}";
            var actors = MoviesContext.Instance.Actors
                .FromSql(sql, "on")
                .Select(a => a.Copy<Actor, ActorModel>());
            ConsoleTable.From(actors).Write();
        }

        private static void PagedActors()
        {
            ConsoleHelper.WriteCaller();

            var sql = "PagedActors {0}, {1}";

            Console.WriteLine("Enter the page size:");
            var pageSize = Console.ReadLine().ToInt();

            Console.WriteLine("Enter the page number:");
            var pageNumber = Console.ReadLine().ToInt();

            var actors = MoviesContext.Instance.Actors
                .FromSql(sql, pageSize, pageNumber)
                .Select(a => a.Copy<Actor, ActorModel>());

            ConsoleTable.From(actors).Write();
        }
    }
}