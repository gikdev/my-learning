using Evently.Modules.Events.Api.Database;
using Evently.Modules.Events.Api.Events;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Modules.Events.Api;

public static class EventsModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateEvent.MapEndpoint(app);
        GetEvent.MapEndpoint(app);
    }

    public static IServiceCollection AddEventsModule(this IServiceCollection services, IConfiguration config)
    {
        string dbConnStr = config.GetConnectionString("Database")
                           ?? throw new ArgumentNullException(nameof(config), "Database connection string is null");

        services.AddDbContext<EventsDbCtx>(o =>
        {
            o.UseNpgsql(
                dbConnStr, 
                o => o
                    .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events)
            )
            .UseSnakeCaseNamingConvention();
        });

        return services;
    }
}
