using InMemoryDB.Repository.Entity;
using Microsoft.EntityFrameworkCore;

namespace InMemoryDB.Data
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}