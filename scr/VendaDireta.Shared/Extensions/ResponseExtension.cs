using FastResults.Results;
using RestSharp;
using VendaDireta.Shared.Messages;

namespace VendaDireta.Shared.Extensions;

public static class ResponseExtension
{
    public static BaseResult Response(this RestResponse restResponse)
    {
        return restResponse.IsSuccessful
            ? BaseResult.Sucess()
            : BaseResult.Failure(restResponse.ErrorMessage!);
    }

    public static BaseResult<TResponse> Response<TResponse>(this RestResponse<TResponse> restResponse)
    {
        return restResponse.IsSuccessful
            ? ValidarResponse(restResponse.Data)
            : BaseResult.Failure<TResponse>(restResponse.ErrorMessage!);
    }

    public static BaseResult<TResponse> Response<TResponse>(TResponse? response)
    {
        return ValidarResponse(response);
    }

    private static BaseResult<TResponse> ValidarResponse<TResponse>(TResponse? response)
    {
        return response is null
            ? BaseResult.Failure<TResponse>(VendaMensagem.Comum.NenhumRegistroEncontrado)
            : response;
    }
}