using Microsoft.EntityFrameworkCore;
using VendaDireta.Infrastructure.Data;

namespace VendaDireta.Presentation.Configuration;

public static class BancoDeDadosConfiguration
{
    public static IServiceCollection AdicionarBancoDeDados(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<VendaDiretaContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Database")));

        services.AddHostedService<MigrationsRunner<VendaDiretaContext>>();

        return services;
    }
}