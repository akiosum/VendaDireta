using System.Net;
using FastResults.Errors;
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
    [ProducesResponseType(typeof(CriarProdutoDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<Guid>> Criar(
        [FromBody] CriarProdutoRequest request,
        CancellationToken cancellationToken)
    {
        BaseResult<CriarProdutoDto> result = await sender.Send(request, cancellationToken);
        return Response(result, HttpStatusCode.Created);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ProdutoDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ProdutoDto>>> ObterTodos(CancellationToken cancellationToken)
    {
        BaseResult<List<ProdutoDto>> result = await sender.Send(new ObterTodosRequest(), cancellationToken);
        return Response(result);
    }

    [HttpGet("id")]
    [ProducesResponseType(typeof(ProdutoDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<ProdutoDto>> ObterPorId(
        [FromQuery] ObterPorIdRequest request,
        CancellationToken cancellationToken)
    {
        BaseResult<ProdutoDto> result = await sender.Send(request, cancellationToken);
        return Response(result);
    }

    [HttpPut("id")]
    [ProducesResponseType(typeof(ProdutoDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<ProdutoDto>> Atualizar()
    {
        return Ok();
    }
}