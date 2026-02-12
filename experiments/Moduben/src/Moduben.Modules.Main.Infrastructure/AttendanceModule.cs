using Moduben.Common.Infrastructure.Outbox;
using Moduben.Common.Presentation.Endpoints;
using Moduben.Modules.Main.Application.Abstractions.Data;
using Moduben.Modules.Main.Infrastructure.Attendees;
using Moduben.Modules.Main.Infrastructure.Authentication;
using Moduben.Modules.Main.Infrastructure.Events;
using Moduben.Modules.Main.Infrastructure.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moduben.Modules.Main.Infrastructure.Database;

namespace Moduben.Modules.Main.Infrastructure;

#pragma warning disable S125 // Sections of code should not be commented out
public static class AttendanceModule {
    public static IServiceCollection AddAttendanceModule(
        this IServiceCollection services,
        IConfiguration configuration
    ) {
        services.AddInfrastructure(configuration);

        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<MainDbCtx>((sp, options) =>
            options
                .UseNpgsql(
                    configuration.GetConnectionString("Database"),
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Main))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>()));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<MainDbCtx>());

        // services.AddScoped<IAttendeeRepository, AttendeeRepository>();

        services.AddScoped<IAttendanceContext, AttendanceContext>();
    }
}
