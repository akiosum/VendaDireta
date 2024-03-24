using VendaDireta.Aplication;
using VendaDireta.Aplication.Abstractions.Contracts;
using VendaDireta.Aplication.Contracts.Services;
using VendaDireta.Aplication.Services;
using VendaDireta.Domain;
using VendaDireta.Domain.Contracts.Abstractions;
using VendaDireta.Infrastructure;

namespace VendaDireta.Presentation.Configuration;

public static class InjecoesDeDependeciasConfiguration
{
    public static IServiceCollection AdicionarInjecao(this IServiceCollection services)
    {
        services.AdicionarRepository();
        services.AdicionarServices();
        services.AdicionarPatterns();

        return services;
    }

    private static void AdicionarPatterns(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblies(ApplicationAssembly.Assembly)
            .AddClasses(filter => filter.AssignableTo<IPatterns>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }

    private static void AdicionarServices(this IServiceCollection services)
    {
        services.AddScoped<ReceitaService>();
        services.AddScoped<BoletoService>();

        services.Scan(scan => scan.FromAssemblies(ApplicationAssembly.Assembly)
            .AddClasses(filter => filter.AssignableTo<IService>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }

    private static void AdicionarRepository(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblies(DomainAssembly.Assembly, InfrastuctureAssembly.Assembly)
            .AddClasses(filter => filter.AssignableTo<IRepository>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }

    private static void AdicionarInfraestrura(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblies(DomainAssembly.Assembly, InfrastuctureAssembly.Assembly)
            .AddClasses(filter => filter.AssignableTo<IInfrastructure>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}