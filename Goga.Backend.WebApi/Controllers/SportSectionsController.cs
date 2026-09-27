using Goga.Backend.Application.Interfaces;
using Goga.Backend.Domain.Sports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Goga.Backend.WebApi.Controllers;

[Authorize]
public sealed class SportSectionsController(
    ISportSectionService sportSectionService,
    ICurrentUserService currentUser) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var sections = await sportSectionService.GetAllAsync(cancellationToken);

        var userEmail = currentUser.Email;
        string? existingEnrollment = null;

        if (!string.IsNullOrEmpty(userEmail))
        {
            existingEnrollment = await sportSectionService.GetUserEnrollmentAsync(userEmail, cancellationToken);
        }

        ViewData["ExistingEnrollment"] = existingEnrollment;
        return View(sections);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Enroll(string sectionName, CancellationToken cancellationToken)
    {
        var userEmail = currentUser.Email;
        if (string.IsNullOrEmpty(userEmail))
        {
            TempData["Error"] = "Необходимо войти в систему";
            return RedirectToAction(nameof(Index));
        }

        var success = await sportSectionService.EnrollAsync(sectionName, userEmail, cancellationToken);
        if (success)
        {
            TempData["Success"] = $"Вы успешно записаны на секцию «{sectionName}»";
        }
        else
        {
            TempData["Error"] = "Не удалось записаться на секцию. Возможно, вы уже записаны на другую секцию.";
        }

        return RedirectToAction(nameof(Index));
    }
}
