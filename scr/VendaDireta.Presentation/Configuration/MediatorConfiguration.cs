using FluentValidation;
using MediatR;
using VendaDireta.Aplication.Behaviors;

namespace VendaDireta.Presentation.Configuration;

public static class MediatorConfiguration
{
    public static IServiceCollection AdicionarMediator(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(Aplication.ApplicationAssembly.Assembly);
        });
        services.AddScoped(typeof(IPipelineBehavior<,>),
            typeof(ValidationPipelineBehavior<,>));
        services.AddValidatorsFromAssembly(Aplication.ApplicationAssembly.Assembly);

        return services;
    }
}