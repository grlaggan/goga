using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Goga.Backend.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Goga.Backend.WebApi.Services;

public sealed class JwtTokenService(IConfiguration configuration) : IJwtTokenService
{
    public AccessTokenResult Create(string email, string? group = null, string? firstName = null, string? lastName = null)
    {
        var now = DateTime.UtcNow;
        var expires = now.AddMinutes(configuration.GetValue("Jwt:AccessTokenMinutes", 60));
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, email),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(ClaimTypes.Name, email),
        };
        if (!string.IsNullOrWhiteSpace(group)) claims.Add(new Claim("group", group));
        if (!string.IsNullOrWhiteSpace(firstName)) claims.Add(new Claim("first_name", firstName));
        if (!string.IsNullOrWhiteSpace(lastName)) claims.Add(new Claim("last_name", lastName));
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),
            SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            notBefore: now,
            expires: expires,
            signingCredentials: credentials);

        return new AccessTokenResult(
            new JwtSecurityTokenHandler().WriteToken(token), expires);
    }
}
