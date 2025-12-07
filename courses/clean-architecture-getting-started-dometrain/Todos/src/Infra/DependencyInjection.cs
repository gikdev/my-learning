using App.Common.Interfaces;
using Infra.Categories.Persistence;
using Infra.Common.Persistence;
using Infra.Todos.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra;

public static class DependencyInjection {
    public static IServiceCollection AddInfra(this IServiceCollection services) {
        services.AddPersistence();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services) {
        services.AddDbContext<MainDbCtx>(options => options.UseSqlite("Data Source = Main.db"));

        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        services.AddScoped<ITodosRepository, TodosRepository>();
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<MainDbCtx>());

        return services;
    }
}
