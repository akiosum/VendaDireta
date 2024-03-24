using FastResults.Controllers;
using FastResults.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VendaDireta.Presentation.Abstractions;

[ProducesErrorResponseType(typeof(Error))]
[ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
public class ApiController(ISender sender) : BaseController
{
}