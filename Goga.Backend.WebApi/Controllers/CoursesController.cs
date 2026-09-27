using Goga.Backend.Application.Courses.Commands;
using Goga.Backend.Application.Courses.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Goga.Backend.WebApi.Controllers;

[Authorize]
public sealed class CoursesController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        return View(await sender.Send(new GetCoursesQuery(), cancellationToken));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Enroll(Guid id, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new EnrollInCourseCommand(id), cancellationToken);
        TempData[result.Success ? "Success" : "Error"] = result.Message;
        return RedirectToAction(nameof(Index));
    }
}
