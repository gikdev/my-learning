using Moduben.Modules.Main.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Moduben.Api.Extensions;

internal static class MigrationExtensions {
    internal static void ApplyMigrations(this IApplicationBuilder app) {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ApplyMigration<MainDbContext>(scope);
    }

    private static void ApplyMigration<TDbContext>(IServiceScope scope) where TDbContext : DbContext {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        context.Database.Migrate();
    }
}
