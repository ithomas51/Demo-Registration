namespace Registration.Api.Endpoints;

using System.Net.Mime;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Diagnostics.HealthChecks;


public static class HealthCheckEndpointsExtensions
{
    public static IEndpointRouteBuilder MapHealthCheckEndpoints(this WebApplication app)
    {
        var endpointGrp = app.MapGroup("/health");

        endpointGrp.MapHealthChecks("/ready", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("ready"),
            ResponseWriter = HealthCheckResponseWriter
        });

        endpointGrp.MapHealthChecks("/live", new HealthCheckOptions { ResponseWriter = HealthCheckResponseWriter });

        return endpointGrp;
    }
    
    private static Task HealthCheckResponseWriter(HttpContext context, HealthReport result)
    {
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsync(result.ToJsonString());
    }
}