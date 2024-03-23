using FastResults.Controllers;
using FastResults.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VendaDireta.Presentation.Abstractions;

[ProducesErrorResponseType(typeof(Error))]
public class ApiController(ISender sender) : BaseController
{
}