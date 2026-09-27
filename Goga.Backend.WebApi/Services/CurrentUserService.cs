using System.Security.Claims;
using Goga.Backend.Application.Interfaces;

namespace Goga.Backend.WebApi.Services;

public sealed class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    private ClaimsPrincipal User => httpContextAccessor.HttpContext?.User ?? new ClaimsPrincipal();

    public string? Subject => User.FindFirstValue("sub") ?? User.FindFirstValue(ClaimTypes.NameIdentifier);
    public string? Email => User.FindFirstValue("email") ?? User.FindFirstValue(ClaimTypes.Email);
    public string? Group => User.FindFirstValue("group") ?? User.FindFirstValue(ClaimTypes.GroupSid);
    public string? FirstName => User.FindFirstValue("first_name") ?? User.FindFirstValue(ClaimTypes.GivenName);
    public string? LastName => User.FindFirstValue("last_name") ?? User.FindFirstValue(ClaimTypes.Surname);
}
