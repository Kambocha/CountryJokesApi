using CountryJokesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryJokesApi.Database
{
    public class JokesDbContext : DbContext
    {
        public JokesDbContext(DbContextOptions<JokesDbContext> options) : base(options)
        {
        }

        public DbSet<Joke> Jokes { get; set; }


    }
}
