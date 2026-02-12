using Ims.Modules.Attendance.Infrastructure.Database;
using Ims.Modules.Events.Infrastructure.Database;
using Ims.Modules.Users.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Ims.Api.Extensions;

internal static class MigrationExtensions {
    public static void ApplyMigrations(this IApplicationBuilder app) {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ApplyMigration<UsersDbContext>(scope);
        ApplyMigration<EventsDbContext>(scope);
        ApplyMigration<AttendanceDbContext>(scope);
    }

    private static void ApplyMigration<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        context.Database.Migrate();
    }
}
