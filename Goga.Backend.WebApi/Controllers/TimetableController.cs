using Goga.Backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Goga.Backend.WebApi.Controllers;

[Authorize]
public sealed class TimetableController(ITimetableService timetableService, ICurrentUserService currentUser) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var group = currentUser.Group?.Trim() ?? string.Empty;

        var today = await timetableService.GetForTodayAsync(group, cancellationToken);
        var tomorrow = await timetableService.GetForTomorrowAsync(group, cancellationToken);
        return View(new TimetablePageViewModel(today, tomorrow));
    }
}

public sealed record TimetablePageViewModel(
    Goga.Backend.Domain.Timetables.Timetable? Today,
    Goga.Backend.Domain.Timetables.Timetable? Tomorrow);
