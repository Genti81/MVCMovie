using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class SeedData
    {
        //public static void Initialize(MvcMovieContext context)
        //{
        //    {
        //        if (context.Movie.Any())
        //        {
        //            return;   // DB has been seeded
        //        }
        //        context.Add(new Movie
        //        {
        //            Title = "God Father",
        //            Genre = "Drama/Crime",
        //            Price = 249,
        //            ReleaseDate = new DateTime(1972, 05, 24)
        //        });
        //        context.SaveChanges();
        //    }
        //}

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "Lord of the rings 3",
                         ReleaseDate = DateTime.Parse("2007-7-11"),
                         Genre = "Fantasy/Action",
                         Rating = "R",
                         Price = 117.99M
                     },

                     new Movie
                     {
                         Title = "Transformers 5",
                         ReleaseDate = DateTime.Parse("2017-4-13"),
                         Genre = "Fantasy/Action/Animation",
                         Rating = "M",
                         Price = 58.99M
                     },

                     new Movie
                     {
                         Title = "Braveheart",
                         ReleaseDate = DateTime.Parse("1995-5-24"),
                         Genre = "History/Action",
                         Rating = "R",
                         Price = 49.99M
                     },

                   new Movie
                   {
                       Title = "Rio 2",
                       ReleaseDate = DateTime.Parse("2015-6-15"),
                       Genre = "Animation",
                       Rating = "J",
                       Price = 34.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
