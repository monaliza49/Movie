using Microsoft.EntityFrameworkCore;
using Movie.Data;

namespace Movie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MovieContext>>()))
            {
                if (context == null || context.Movieee == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Movieee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movieee.AddRange(
                  
                    
                      
                    new Movieee
                    {
                        Title = "HarryPotter 2",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "MAGIC, ACTION",
                        Price = 90.99M,
                         Rating = "R"
                    },

                    new Movieee
                    {
                        Title = "HarryPotter 3",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "MAGIC, ACTION",
                        Price = 90.99M,
                         Rating = "R"
                    },

                    new Movieee
                    {
                        Title = "HarryPotter 4",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "MAGIC, ACTION",
                        Price = 90.99M,
                         Rating = "R"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}