using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.EF
{
    public class SuperheroContext: DbContext
    {
        public SuperheroContext(DbContextOptions<SuperheroContext> options) : base(options)
        {
        }

        public DbSet<Superhero> Superheroes { get; set; }
    }
}
