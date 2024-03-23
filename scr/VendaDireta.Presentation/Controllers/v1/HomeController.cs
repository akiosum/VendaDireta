using FastResults.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendaDireta.Presentation.Abstractions;

namespace VendaDireta.Presentation.Controllers.v1;

[Route("v1/[controller]")]
public class HomeController(ISender sender) : ApiController(sender)
{
    [HttpGet]
    public ActionResult Api() => Response(BaseResult.Sucess(), "Api está online!");
}