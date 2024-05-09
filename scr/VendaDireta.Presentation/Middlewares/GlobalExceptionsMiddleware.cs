using System.Net;
using FastResults.Errors;
using FastResults.Results;
using FluentValidation;
using VendaDireta.Shared.Errors;

namespace VendaDireta.Presentation.Middlewares;

public class GlobalExceptionsMiddleware(ILogger<GlobalExceptionsMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            logger.LogInformation($"Rota - {context.Request.Path}");
            await next(context);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, $"Erro - {exception.Message}");
            var response = context.Response;
            response.ContentType = "application/json";

            switch (exception)
            {
                case UnauthorizedAccessException:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await response.WriteAsJsonAsync(new BaseResponse<Error>(VendaErro.Comum.AcessoNegado));
                    break;
                case ValidationException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await response.WriteAsJsonAsync(
                        new BaseResponse<Error>(VendaErro.Comum.Validacao(exception.Message)));
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await response.WriteAsJsonAsync(new BaseResponse<Error>(VendaErro.Comum.ErroInterno));
                    break;
            }
        }
    }
}