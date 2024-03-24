using System.Net;
using FastResults.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendaDireta.Aplication.Requests.Receita;
using VendaDireta.Presentation.Abstractions;

namespace VendaDireta.Presentation.Controllers.v1;

[Route("v1/[controller]")]
public class ReceitaController(ISender sender) : ApiController(sender)
{
    [HttpPost]
    public async Task<ActionResult> Criar(
        [FromBody] CriarReceitaRequest request,
        CancellationToken cancellationToken)
    {
        BaseResult result = await sender.Send(request, cancellationToken);
        return Response(result, httpStatus: HttpStatusCode.Created);
    }
}