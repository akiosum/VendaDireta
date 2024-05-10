using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendaDireta.Presentation.Abstractions;

namespace VendaDireta.Presentation.Controllers.v1;

[Route("v1/[controller]")]
public class EstoqueController(ISender sender) : ApiController(sender)
{
    public async Task<ActionResult> Alterar()
    {
        return Ok();
    }
}