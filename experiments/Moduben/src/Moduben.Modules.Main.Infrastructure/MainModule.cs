using Moduben.Common.Infrastructure.Interceptors;
using Moduben.Common.Presentation.Endpoints;
using Moduben.Modules.Main.Application.Abstractions.Data;
using Moduben.Modules.Main.Infrastructure.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moduben.Modules.Main.Infrastructure.Database;
using Moduben.Modules.Main.Application.Abstractions.Authentication;
using MassTransit;

namespace Moduben.Modules.Main.Infrastructure;

public static class MainModule {
    public static IServiceCollection AddMainModule(
        this IServiceCollection services,
        IConfiguration configuration
    ) {
        services.AddInfrastructure(configuration);

        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        return services;
    }

#pragma warning disable S125 // Sections of code should not be commented out
#pragma warning disable IDE0060 // Remove unused parameter
    public static void ConfigureConsumers(
        IRegistrationConfigurator registrationConfigurator
    ) {
        // registrationConfigurator.AddConsumer<UserRegisteredIntegrationEventConsumer>();
    }
#pragma warning restore IDE0060 // Remove unused parameter
#pragma warning restore S125 // Sections of code should not be commented out

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

#pragma warning disable S125 // Sections of code should not be commented out
        // services.AddScoped<IAttendeeRepository, AttendeeRepository>();
#pragma warning restore S125 // Sections of code should not be commented out

        services.AddScoped<IMainCtx, MainCtx>();
    }
}
