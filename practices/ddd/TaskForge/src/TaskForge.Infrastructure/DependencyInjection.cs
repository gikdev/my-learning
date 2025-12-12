using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskForge.Domain.Common.Interfaces;
using TaskForge.Infrastructure.Common.Persistence;
using TaskForge.Infrastructure.Labels.Persistence;
using TaskForge.Infrastructure.Projects.Persistence;

namespace TaskForge.Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructureStuff(this IServiceCollection services) {
        services.AddPersistenceStuff();

        return services;
    }

    private static IServiceCollection AddPersistenceStuff(this IServiceCollection services) {
        services.AddDbContext<TaskForgeDbContext>(options => {
            options.UseSqlite("Data Source = TaskForge.db");
        });

        services.AddScoped<ILabelsRepository, LabelsRepository>();
        services.AddScoped<IProjectsRepository, ProjectsRepository>();

        return services;
    }
}
