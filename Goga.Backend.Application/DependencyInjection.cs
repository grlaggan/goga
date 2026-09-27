using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Goga.Backend.Application.Authentication;
using Goga.Backend.Application.Interfaces;
using Goga.Backend.Application.Timetables;
using Goga.Backend.Application.Sports;

namespace Goga.Backend.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ITimetableService, TimetableService>();
        services.AddScoped<ISportSectionService, SportSectionService>();

        return services;
    }
}