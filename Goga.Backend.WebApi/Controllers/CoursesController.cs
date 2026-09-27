using Goga.Backend.Application.Courses.Commands;
using Goga.Backend.Application.Courses.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Goga.Backend.WebApi.Controllers;

[ApiController]
[Route("api/courses")]
[Authorize]
public sealed class CoursesController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken) =>
        Ok(await sender.Send(new GetCoursesQuery(), cancellationToken));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCourseQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost("{id:guid}/enroll")]
    public async Task<IActionResult> Enroll(Guid id, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new EnrollInCourseCommand(id), cancellationToken);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
