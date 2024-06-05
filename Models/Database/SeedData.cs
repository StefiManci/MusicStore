using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
namespace MusicStore.Models.Database
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (!context.Musics.Any())
                {
                    context.Musics.AddRange(
                    new Album
                    {
                        Title = "Despacito",
                        Author = "Luis Fonsi",
                        ReleaseYear = 2023,
                        Genre = "Pop"
                    },
                    new Album
                    {
                        Title = "What a Wonderful World",
                        Author = "Louis Armstrong",
                        ReleaseYear = 2023,
                        Genre = "Jazz"
                    },
                    new Album
                    {
                        Title = "Immigrant",
                        Author = "Led Zeppelin",
                        ReleaseYear = 2023,
                        Genre = "Rock"
                    },
                    new Album
                    {
                        Title = "Nuk Kan Besu",
                        Author = "Noizy",
                        ReleaseYear = 2023,
                        Genre = "HipHop"
                    },
                     new Album
                     {
                         Title = "Nuk Kan Besu",
                         Author = "Noizy",
                         ReleaseYear = 2023,
                         Genre = "HipHop"
                     }
                    );
                    context.SaveChanges();
                }
            }


        }
    }
}