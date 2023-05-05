using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RepositoryContext(
                serviceProvider.GetRequiredService<DbContextOptions<RepositoryContext>>()))
            {
                // Look for any board games.
                if (context.Books.Any())
                {
                    return;   // Data was already seeded
                }

                context.Books.AddRange(
                    new Book { Title = "Hamlet", Author = "William Shakespeare" },
                    new Book { Title = "Replay", Author = "Ken Grimwood" },
                    new Book { Title = "Flowers for Algernon", Author = "Daniel Keyes" },
                    new Book { Title = "The First Fifteen Lives of Harry August", Author = "Claire North" },
                    new Book { Title = "Rebecca", Author = "Daphne du Maurier" },
                    new Book { Title = "The Book Thief", Author = "Markus Zusak" }
                );

                context.SaveChanges();
            }
        }
    }
}
