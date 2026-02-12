using Moduben.Common.Application.Caching;
using Moduben.Common.Application.Clock;
using Moduben.Common.Application.Data;
using Moduben.Common.Application.EventBus;
using Moduben.Common.Infrastructure.Authentication;
using Moduben.Common.Infrastructure.Authorization;
using Moduben.Common.Infrastructure.Caching;
using Moduben.Common.Infrastructure.Clock;
using Moduben.Common.Infrastructure.Data;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using Moduben.Common.Infrastructure.Interceptors;

namespace Moduben.Common.Infrastructure;

public static class InfrastructureConfiguration {
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        Action<IRegistrationConfigurator>[] moduleConfigureConsumers,
        string databaseConnectionString
    ) {
        services.AddAuthenticationInternal();

        services.AddAuthorizationInternal();

        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.TryAddScoped<IDbConnectionFactory, DbConnectionFactory>();

        services.TryAddSingleton<PublishDomainEventsInterceptor>();

        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddDistributedMemoryCache();

        services.TryAddSingleton<ICacheService, CacheService>();

        services.TryAddSingleton<IEventBus, EventBus.EventBus>();

        services.AddMassTransit(configure => {
            foreach (Action<IRegistrationConfigurator> configureConsumer in moduleConfigureConsumers) {
                configureConsumer(configure);
            }

            configure.SetKebabCaseEndpointNameFormatter();

            configure.UsingInMemory((context, cfg) => {
                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
