using FastResults.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendaDireta.Aplication.Dto.Produto;
using VendaDireta.Aplication.Requests.Produto;
using VendaDireta.Presentation.Abstractions;

namespace VendaDireta.Presentation.Controllers.v1;

[Route("v1/[controller]")]
public class ProdutoController(ISender sender) : ApiController(sender)
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Criar(
        [FromBody] CriarProdutoRequest request,
        CancellationToken cancellationToken)
    {
        BaseResult<Guid> result = await sender.Send(request, cancellationToken);
        return Response(result);
    }

    [HttpGet]
    public async Task<ActionResult<ProdutoDto>> ObterTodos(CancellationToken cancellationToken)
    {
        BaseResult<List<ProdutoDto>> result = await sender.Send(new ObterTodosRequest(), cancellationToken);
        return Response(result);
    }

    [HttpGet("id")]
    public async Task<ActionResult<ProdutoDto>> ObterPorId(
        [FromQuery] ObterPorIdRequest request,
        CancellationToken cancellationToken)
    {
        BaseResult<ProdutoDto> result = await sender.Send(request, cancellationToken);
        return Response(result);
    }
}