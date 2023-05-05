using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = _ = modelBuilder.Entity<Book>(book =>
            {
                book.Property(p => p.Id).HasValueGenerator<IdValueGenerator>();
            });
        }

        public DbSet<Book> Books { get; set; } = null!;
    }
}
