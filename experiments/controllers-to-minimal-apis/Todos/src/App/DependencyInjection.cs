using App.Common.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace App;

public static class DependencyInjection {
    public static IServiceCollection AddApp(this IServiceCollection services) {
        services.AddMediatR(options => {
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));

            options.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));

        return services;
    }
}
