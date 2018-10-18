using System.Linq;
using ConsoleTables;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Entity;
using MoviesApp.Extensions;
using MoviesApp.Models;

namespace MoviesApp.Helpers
{
    public static class RawSqlHelper
    {
        public static void RunAll()
        {
            SelectActor();
            SelectActorWithParameter();
            SelectSingleFilm();
        }

        private static void SelectActor()
        {
            ConsoleHelper.WriteCaller();

            var sql = "select * from actor where actorid = 12";
            var films = MoviesContext.Instance.Actors
                .FromSql(sql)
                .Select(f => ObjectExtensions.Copy<Actor, ActorModel>(f));
            ConsoleTable.From(films).Write();
        }

        private static void SelectActorWithParameter()
        {
            ConsoleHelper.WriteCaller();

            var sql = "select * from actor where actorid = {0}";
            var actors = MoviesContext.Instance.Actors
                .FromSql(sql, 2)
                .Select(a => a.Copy<Actor, ActorModel>());
            ConsoleTable.From(actors).Write();
        }

        private static void SelectSingleFilm()
        {
            ConsoleHelper.WriteCaller();

            var sql = "select top 1 * from film";
            var films = MoviesContext.Instance.Films
                .FromSql(sql)
                .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }
    }
}