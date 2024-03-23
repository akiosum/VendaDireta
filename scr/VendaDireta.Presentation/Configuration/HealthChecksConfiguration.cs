using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using VendaDireta.Infrastructure.Data;

namespace VendaDireta.Presentation.Configuration;

public static class HealthChecksConfiguration
{
    public static IServiceCollection AdicionarHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddDbContextCheck<VendaDiretaContext>(tags: new[] { "Database" });

        services.AddHealthChecksUI()
            .AddInMemoryStorage();

        return services;
    }

    public static void UseHealthChecks(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/status", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        app.UseHealthChecksUI(options => { options.UIPath = "/status-dashboard"; });
    }
}