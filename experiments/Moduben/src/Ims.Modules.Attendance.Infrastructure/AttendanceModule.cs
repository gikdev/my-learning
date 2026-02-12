using Ims.Common.Application.EventBus;
using Ims.Common.Application.Messaging;
using Ims.Common.Infrastructure.Outbox;
using Ims.Common.Presentation.Endpoints;
using Ims.Modules.Attendance.Application.Abstractions.Authentication;
using Ims.Modules.Attendance.Application.Abstractions.Data;
using Ims.Modules.Attendance.Domain.Attendees;
using Ims.Modules.Attendance.Domain.Events;
using Ims.Modules.Attendance.Domain.Tickets;
using Ims.Modules.Attendance.Infrastructure.Attendees;
using Ims.Modules.Attendance.Infrastructure.Authentication;
using Ims.Modules.Attendance.Infrastructure.Database;
using Ims.Modules.Attendance.Infrastructure.Events;
using Ims.Modules.Attendance.Infrastructure.Inbox;
using Ims.Modules.Attendance.Infrastructure.Outbox;
using Ims.Modules.Attendance.Infrastructure.Tickets;
using Ims.Modules.Attendance.Presentation;
using Ims.Modules.Events.IntegrationEvents;
using Ims.Modules.Ticketing.IntegrationEvents;
using Ims.Modules.Users.IntegrationEvents;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Ims.Modules.Attendance.Infrastructure;

public static class AttendanceModule {
    public static IServiceCollection AddAttendanceModule(
        this IServiceCollection services,
        IConfiguration          configuration
    ) {
        services.AddDomainEventHandlers();

        services.AddIntegrationEventHandlers();

        services.AddInfrastructure(configuration);

        services.AddEndpoints(AssemblyReference.Assembly);

        return services;
    }

    public static void ConfigureConsumers(IRegistrationConfigurator registrationConfigurator, string instanceId) {
        registrationConfigurator.AddConsumer<IntegrationEventConsumer<UserRegisteredIntegrationEvent>>()
            .Endpoint(c => c.InstanceId = instanceId);

        registrationConfigurator.AddConsumer<IntegrationEventConsumer<UserProfileUpdatedIntegrationEvent>>()
            .Endpoint(c => c.InstanceId = instanceId);

        registrationConfigurator.AddConsumer<IntegrationEventConsumer<EventPublishedIntegrationEvent>>()
            .Endpoint(c => c.InstanceId = instanceId);

        registrationConfigurator.AddConsumer<IntegrationEventConsumer<TicketIssuedIntegrationEvent>>()
            .Endpoint(c => c.InstanceId = instanceId);

        registrationConfigurator.AddConsumer<IntegrationEventConsumer<EventCancellationStartedIntegrationEvent>>()
            .Endpoint(c => c.InstanceId = instanceId);
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<AttendanceDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    configuration.GetConnectionString("Database"),
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Attendance))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(sp.GetRequiredService<InsertOutboxMessagesInterceptor>()));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AttendanceDbContext>());

        services.AddScoped<IAttendeeRepository, AttendeeRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();

        services.AddScoped<IAttendanceContext, AttendanceContext>();

        services.Configure<OutboxOptions>(configuration.GetSection("Attendance:Outbox"));

        services.ConfigureOptions<ConfigureProcessOutboxJob>();

        services.Configure<InboxOptions>(configuration.GetSection("Attendance:Inbox"));

        services.ConfigureOptions<ConfigureProcessInboxJob>();
    }

    private static void AddDomainEventHandlers(this IServiceCollection services) {
        Type[] domainEventHandlers = Application.AssemblyReference.Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IDomainEventHandler)))
            .ToArray();

        foreach (Type domainEventHandler in domainEventHandlers) {
            services.TryAddScoped(domainEventHandler);

            Type domainEvent = domainEventHandler
                .GetInterfaces()
                .Single(i => i.IsGenericType)
                .GetGenericArguments()
                .Single();

            Type closedIdempotentHandler = typeof(IdempotentDomainEventHandler<>).MakeGenericType(domainEvent);

            services.Decorate(domainEventHandler, closedIdempotentHandler);
        }
    }

    private static void AddIntegrationEventHandlers(this IServiceCollection services) {
        Type[] integrationEventHandlers = AssemblyReference.Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IIntegrationEventHandler)))
            .ToArray();

        foreach (Type integrationEventHandler in integrationEventHandlers) {
            services.TryAddScoped(integrationEventHandler);

            Type integrationEvent = integrationEventHandler
                .GetInterfaces()
                .Single(i => i.IsGenericType)
                .GetGenericArguments()
                .Single();

            Type closedIdempotentHandler =
                typeof(IdempotentIntegrationEventHandler<>).MakeGenericType(integrationEvent);

            services.Decorate(integrationEventHandler, closedIdempotentHandler);
        }
    }
}
