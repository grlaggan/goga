using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Goga.Backend.Application.Interfaces;
using Goga.Backend.Persistence.Users;
using Goga.Backend.Persistence.Courses;
using Goga.Backend.Persistence.Timetables;
using Goga.Backend.Persistence.News;

namespace Goga.Backend.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionStringBuilder = new MySqlConnectionStringBuilder
        {
            Server = configuration.GetConnectionString("MySql"),
            Port = configuration["Database:Port"] != null
                ? uint.Parse(configuration["Database:Port"]!)
                : 3307,
            UserID = configuration["Database:UserId"],
            Password = configuration["Database:Password"],
            Database = configuration["Database:DatabaseName"],
            SslMode = MySqlSslMode.Required
        };

        ServerVersion serverVersion;
        using (var connection = new MySqlConnection(connectionStringBuilder.ConnectionString))
        {
            connection.Open();
            serverVersion = ServerVersion.Parse(connection.ServerVersion);
        }

        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionStringBuilder.ConnectionString, serverVersion));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ITimetableRepository, TimetableRepository>();
        services.AddScoped<INewsRepository, NewsRepository>();

        return services;
    }
}
