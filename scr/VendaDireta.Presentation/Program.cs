using VendaDireta.Presentation.Configuration;
using VendaDireta.Presentation.Middlewares;

namespace VendaDireta.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AdicionarConfiguracoes(builder.Configuration)
            .AdicionarHealthChecks();

        builder.Services.AddTransient<GlobalExceptionsMiddleware>();

        var app = builder.Build();

        app.UseMiddleware<GlobalExceptionsMiddleware>();
        app.UseHttpsRedirection();
        app.UseHealthChecks();
        app.UseCors("Productions");
        app.UseSwaggerDocumentacao();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}