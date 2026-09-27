using Microsoft.AspNetCore.Mvc;
using Goga.Backend.Application.News.Queries;
using MediatR;

namespace Goga.Backend.WebApi.Controllers;

public sealed class HomeController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken) =>
        View(await sender.Send(new GetNewsQuery(), cancellationToken));
}
