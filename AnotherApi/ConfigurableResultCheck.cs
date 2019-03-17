using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AnotherApi
{
    public class ConfigurableResultCheck: IHealthCheck
    {
        public IConfiguration Configuration { get; }

        public ConfigurableResultCheck(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (bool.Parse(Configuration["ReturnError"]))
            {
                return await Task.FromResult(HealthCheckResult.Unhealthy());
            }
            return await Task.FromResult(HealthCheckResult.Healthy());
        }
    }
}
