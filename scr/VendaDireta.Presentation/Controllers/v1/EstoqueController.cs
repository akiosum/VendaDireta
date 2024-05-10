using FastResults.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendaDireta.Aplication.Requests.Estoque;
using VendaDireta.Presentation.Abstractions;
using VendaDireta.Shared.Messages;

namespace VendaDireta.Presentation.Controllers.v1;

[Route("v1/[controller]")]
public class EstoqueController(ISender sender) : ApiController(sender)
{
    [HttpPut]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<ActionResult<string>> Atualizar([FromBody] AtualizarEstoqueRequest request,
        CancellationToken cancellationToken)
    {
        BaseResult result = await sender.Send(request, cancellationToken);
        return Response(result, VendaMensagem.Comum.RegistroAlteradoComSucesso);
    }
}