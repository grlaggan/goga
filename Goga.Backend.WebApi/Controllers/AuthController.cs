using Goga.Backend.Application.Authentication.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Goga.Backend.WebApi.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController(ISender sender) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginCommand command,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result is null
            ? Unauthorized(new { message = "Неверный email или пароль." })
            : Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        RegisterCommand command,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result is null
            ? Conflict(new { message = "Пользователь уже существует или данные некорректны." })
            : Ok(result);
    }
}
