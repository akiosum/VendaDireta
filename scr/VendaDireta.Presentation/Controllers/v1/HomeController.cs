using FastResults.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendaDireta.Aplication.Requests.ArtBackup;
using VendaDireta.Aplication.UseCases.ArtBackupUseCase;
using VendaDireta.Presentation.Abstractions;

namespace VendaDireta.Presentation.Controllers.v1;

[Route("v1/[controller]")]
public class HomeController(ISender sender) : ApiController(sender)
{
    [HttpGet]
    public ActionResult Api() => Response(BaseResult.Sucess(), "Api está online!");

    [HttpGet("relatorio")]
    public async Task<ActionResult> Teste()
    {
        var a = await sender.Send(new ObterRelatorioArtBackupRequest());
        return Response(a);
    }
}