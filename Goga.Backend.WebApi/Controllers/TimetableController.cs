using Goga.Backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Goga.Backend.WebApi.Controllers;

[ApiController]
[Route("api/timetable")]
[Authorize]
public sealed class TimetableController(ITimetableService timetableService, ICurrentUserService currentUser)
    : ControllerBase
{
    [HttpGet("today")]
    public async Task<IActionResult> GetToday(CancellationToken cancellationToken)
    {
        var timetable = await timetableService.GetForTodayAsync(currentUser.Group!, cancellationToken);
        return Ok(timetable);
    }

    [HttpGet("tomorrow")]
    public async Task<IActionResult> GetTomorrow(CancellationToken cancellationToken)
    {
        var timetable = await timetableService.GetForTomorrowAsync(currentUser.Group!, cancellationToken);
        return Ok(timetable);
    }
}
