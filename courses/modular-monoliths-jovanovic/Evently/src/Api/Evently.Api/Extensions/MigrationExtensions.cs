using Evently.Modules.Events.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace Evently.Api.Extensions;

internal static class MigrationExtensions
{
    internal static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ApplyMigration<EventsDbCtx>(scope);
    }

    private static void ApplyMigration<TDbCtx>(IServiceScope scope) where TDbCtx : DbContext
    {
        using TDbCtx ctx = scope.ServiceProvider.GetRequiredService<TDbCtx>();

        ctx.Database.Migrate();
    }
}
