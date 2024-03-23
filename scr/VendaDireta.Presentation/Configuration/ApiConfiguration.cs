using Serilog;

namespace VendaDireta.Presentation.Configuration;

public static class ApiConfiguration
{
    public static IServiceCollection AdicionarConfiguracoes(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers()
            .ConfigureApiBehaviorOptions(conf => { conf.SuppressModelStateInvalidFilter = true; });
        services.AddEndpointsApiExplorer();

        services.AdicionarSwagger();
        services.AdicionarLog(configuration);
        services.AdicionarCors();
        services.AdicionarBancoDeDados(configuration);
        services.AdicionarInjecao();
        services.AdicionarMediator();

        return services;
    }

    private static void AdicionarLog(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddLogging(options =>
        {
            options.ClearProviders();
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            options.AddSerilog(logger);
        });
    }

    private static void AdicionarCors(this IServiceCollection services)
    {
        services.AddCors(options => options.AddPolicy("Productions",
            cors => cors
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));
    }
}