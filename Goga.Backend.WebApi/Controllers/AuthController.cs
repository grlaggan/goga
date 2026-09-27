using Goga.Backend.Application.Authentication.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Goga.Backend.WebApi.Controllers;

public sealed class AuthController(ISender sender) : Controller
{
    [HttpGet]
    public IActionResult Login() => View(new LoginViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return View(model);
        var result = await sender.Send(new LoginCommand(model.Email, model.Password), cancellationToken);
        if (result is null)
        {
            ModelState.AddModelError(string.Empty, "Неверный email или пароль.");
            return View(model);
        }
        SetToken(result.AccessToken);
        return RedirectToAction("Index", "Courses");
    }

    [HttpGet]
    public IActionResult Register() => View(new RegisterViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return View(model);
        var result = await sender.Send(new RegisterCommand(model.Email, model.Password, model.Group, model.FirstName, model.LastName), cancellationToken);
        if (result is null)
        {
            ModelState.AddModelError(string.Empty, "Пользователь уже существует или данные некорректны.");
            return View(model);
        }
        SetToken(result.AccessToken);
        return RedirectToAction("Index", "Courses");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("goga_access_token");
        return RedirectToAction("Index", "Home");
    }

    private void SetToken(string token) => Response.Cookies.Append("goga_access_token", token, new CookieOptions
    {
        HttpOnly = true,
        Secure = Request.IsHttps,
        SameSite = SameSiteMode.Strict,
        Expires = DateTimeOffset.UtcNow.AddHours(1)
    });
}

public class LoginViewModel
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public sealed class RegisterViewModel : LoginViewModel
{
    public string Group { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
