using Evently.Modules.Events.Application;
using Evently.Modules.Events.Application.Abstractions.Data;
using Evently.Modules.Events.Domain.Events;
using Evently.Modules.Events.Infrastructure.Data;
using Evently.Modules.Events.Infrastructure.Database;
using Evently.Modules.Events.Infrastructure.Events;
using Evently.Modules.Events.Presentation.Events;
using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace Evently.Modules.Events.Infrastructure;

public static class EventsModule {
    public static void MapEndpoints(IEndpointRouteBuilder app) {
        EventEndpoints.MapEndpoints(app);
    }

    public static IServiceCollection AddEventsModule(this IServiceCollection services, IConfiguration config) {
        services.AddMediatR(c => {
            c.RegisterServicesFromAssembly(AssemblyReference.Assembly);
        });

        services.AddValidatorsFromAssembly(AssemblyReference.Assembly, includeInternalTypes: true);

        services.AddInfrastructure(config);

        return services;
    }

    private static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config) {
        string dbConnStr = config.GetConnectionString("Database")
                           ?? throw new ArgumentNullException(nameof(config), "Database connection string is null");

        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(dbConnStr).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnFactory, DbConnFactory>();

        services.AddDbContext<EventsDbCtx>(o => {
            o
                .UseNpgsql(
                    dbConnStr,
                    o => o
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events)
                )
                .UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IEventRepo, EventRepo>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EventsDbCtx>());

        return services;
    }
}
