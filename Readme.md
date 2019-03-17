# Playing with ASP.NET Core Healchecks

## What is  healthcheck?

My definition: 
> "Health checks verify that a resource is able to accomplish with its mission."

Health checks are exposed by an app as HTTP endpoints. Health check endpoints can be configured for a variety of real-time monitoring scenarios:

- Health probes can be used by container orchestrators and load balancers to check an app's status. For example, a container orchestrator may respond to a failing health check by halting a rolling deployment or restarting a container. A load balancer might react to an unhealthy app by routing traffic away from the failing instance to a healthy instance.
- Use of memory, disk, and other physical server resources can be monitored for healthy status.
- Health checks can test an app's dependencies, such as databases and external service endpoints, to confirm availability and normal functioning.


### Liveness vs readyness

bla bla

## The "old" way

In the old days, people used to create an endpoint that checks application dependencies. If it returned an OK result web inferred that application was running fine.

Later, using a monitoring solution as Nagios, we periodically sent rewuest to that endpoint, to monitor liveness.

```csharp
[Route("working")]
public ActionResult Working()
{
    using (var connection = new SqlConnection(_connectionString))
    {
        try
        {
            connection.Open();
        }
        catch (SqlException)
        {
            return new HttpStatusCodeResult(503, "Generic error");
        }
    }

    return new EmptyResult();
}
```
## ASP.NET Core before 2.2

Xabaril guys created a healthcheck library to fill the gap in Asp.Net Core ecosystem as no health checks libraries were available in version 2.1 and prenious. This library, called BeatPulse, is still supported and can be found here https://github.com/Xabaril/BeatPulse

## Native support in ASP.NET Core 2.2

Starting in ASP.NET Core 2.2  Microsoft is rolling out their own health checks integration: https://docs.microsoft.com/es-es/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-2.2

Beatpulse project is now focused in contributing towards this library, adding extensions for the new Microsoft health checks available in this repository: https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks

## Future...

New features are coming in .NET Core 3

## References

- A good initial introduction:  https://blog.elmah.io/asp-net-core-2-2-health-checks-explained/

- Official documentation:
   - https://docs.microsoft.com/es-es/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-2.2

   - https://docs.microsoft.com/es-es/dotnet/standard/microservices-architecture/implement-resilient-applications/monitor-app-health (Coming from Cesar de la Torre microservices book)

- Azure monitor: https://docs.microsoft.com/es-es/azure/azure-monitor/

- Azure app insights: https://docs.microsoft.com/es-es/azure/azure-monitor/app/app-insights-overview

- BeatPulse (use it before .NET Core 2.2): https://github.com/Xabaril/BeatPulse

- BeatPulse liveness and UI port to new Microsoft Health Checks feature included on ASP.NET Core 2.2 : https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks

