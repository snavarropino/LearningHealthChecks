using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.EF
{
    public class DesingTimeContext : IDesignTimeDbContextFactory<SuperheroContext>
    {
        public SuperheroContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SuperheroContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SuperheroesHealthChecks;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new SuperheroContext(optionsBuilder.Options);
        }
    }
}
