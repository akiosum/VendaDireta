using VendaDireta.Domain;
using VendaDireta.Domain.Contracts.Abstractions;
using VendaDireta.Infrastructure;

namespace VendaDireta.Presentation.Configuration;

public static class InjecoesDeDependeciasConfiguration
{
    public static IServiceCollection AdicionarInjecao(this IServiceCollection services)
    {
        services.AdicionarRepository();

        return services;
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