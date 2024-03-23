using Microsoft.OpenApi.Models;

namespace VendaDireta.Presentation.Configuration;

public static class SwaggerConfiguration
{
    public static IServiceCollection AdicionarSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Venda Direta, a mais direta",
                Version = "V1",
                Description = "Projeto de desmostração e funcionalidades de um sistema de vendas e controle de estoque",
                Contact = new OpenApiContact { Name = "Akio Serizawa" }
            });
        });
        
        return services;
    }
    
    public static void UseSwaggerDocumentacao(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}