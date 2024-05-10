using Microsoft.EntityFrameworkCore;
using VendaDireta.Domain.Contracts.Repositories;
using VendaDireta.Infrastructure.Data;

namespace VendaDireta.Presentation.Configuration;

public static class BancoDeDadosConfiguration
{
    public static IServiceCollection AdicionarBancoDeDados(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<IUnitOfWork, VendaDiretaContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Database")));

        services.AddHostedService<MigrationsRunner<VendaDiretaContext>>();

        return services;
    }
}