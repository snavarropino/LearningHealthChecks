using Api.EF;
using Api.Extensions;
using Api.Model;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .MigrateDbContext<SuperheroContext>((context, services) =>
                {
                    context.Superheroes.Add(new Superhero()
                    {
                        Name = "NUKLON"
                    });

                    context.SaveChanges();
                })
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                .UseStartup<Startup>();
    }
}
