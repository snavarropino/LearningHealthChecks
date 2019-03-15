using System.Data.SqlClient;
using Api.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public string ConnectionString { get; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddDbContext<SuperheroContext>(options =>
                options.UseSqlServer(ConnectionString));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddHealthChecks()
                    .AddCheck("sqlDatabase", () =>
                    {
                        using (var connection = new SqlConnection(ConnectionString))
                        {
                            try
                            {
                                connection.Open();
                            }
                            catch (SqlException)
                            {
                                return HealthCheckResult.Unhealthy();
                            }
                        }

                        return HealthCheckResult.Healthy();
                    })
                    .AddDbContextCheck<SuperheroContext>(); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHealthChecks("/healthCheck");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
