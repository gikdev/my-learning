namespace Api;

public static class DependencyInjection {
    public static IServiceCollection AddApi(this IServiceCollection services) {
        // services.AddControllers();
        services.AddAuthorization();
        services.AddOpenApi();
        services.AddProblemDetails();

        return services;
    }
}
