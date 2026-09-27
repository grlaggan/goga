using Goga.Backend.Application.Protected.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Goga.Backend.WebApi.Controllers;

[ApiController]
[Route("api/protected")]
[Authorize]
public sealed class ProtectedController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(new GetProtectedResourceQuery(), cancellationToken));
    }
}
