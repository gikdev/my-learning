using Dapper;
using Ims.Common.Application.Caching;
using Ims.Common.Application.Clock;
using Ims.Common.Application.Data;
using Ims.Common.Application.EventBus;
using Ims.Common.Infrastructure.Authentication;
using Ims.Common.Infrastructure.Authorization;
using Ims.Common.Infrastructure.Caching;
using Ims.Common.Infrastructure.Clock;
using Ims.Common.Infrastructure.Data;
using Ims.Common.Infrastructure.EventBus;
using Ims.Common.Infrastructure.Outbox;
using MassTransit;
using MassTransit.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Quartz;
using StackExchange.Redis;

namespace Ims.Common.Infrastructure;

public static class InfrastructureConfiguration {
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection                     services,
        string                                      serviceName,
        Action<IRegistrationConfigurator, string>[] moduleConfigureConsumers,
        RabbitMqSettings                            rabbitMqSettings,
        string                                      databaseConnectionString,
        string                                      redisConnectionString
    ) {
        services.AddAuthenticationInternal();

        services.AddAuthorizationInternal();

        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.TryAddSingleton<IEventBus, EventBus.EventBus>();

        services.TryAddSingleton<InsertOutboxMessagesInterceptor>();

        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.TryAddScoped<IDbConnectionFactory, DbConnectionFactory>();

        SqlMapper.AddTypeHandler(new GenericArrayHandler<string>());

        services.AddQuartz(configurator => {
            var scheduler = Guid.NewGuid();
            configurator.SchedulerId   = $"default-id-{scheduler}";
            configurator.SchedulerName = $"default-name-{scheduler}";
        });

        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

        try {
            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
            services.AddSingleton(connectionMultiplexer);

            services.AddStackExchangeRedisCache(options =>
                options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));
        } catch {
            services.AddDistributedMemoryCache();
        }

        services.TryAddSingleton<ICacheService, CacheService>();

        services.AddMassTransit(configure => {
            string instanceId = serviceName.ToLowerInvariant().Replace('.', '-');

            foreach (Action<IRegistrationConfigurator, string> configureConsumers in moduleConfigureConsumers) {
                configureConsumers(configure, instanceId);
            }

            configure.SetKebabCaseEndpointNameFormatter();

            configure.UsingRabbitMq((context, cfg) => {
                cfg.Host(new Uri(rabbitMqSettings.Host), h => {
                    h.Username(rabbitMqSettings.Username);
                    h.Password(rabbitMqSettings.Password);
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        services
            .AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(serviceName))
            .WithTracing(tracing => {
                tracing
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddEntityFrameworkCoreInstrumentation()
                    .AddRedisInstrumentation()
                    .AddNpgsql()
                    .AddSource(DiagnosticHeaders.DefaultListenerName);

                tracing.AddOtlpExporter();
            });

        return services;
    }
}
