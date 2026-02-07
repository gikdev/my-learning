using DevHabit.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace DevHabit.Api.Extensions;

public static class DbExtensions
{
    public static async Task ApplyMigrationsAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        await using var dbCtx = scope.ServiceProvider.GetRequiredService<AppDbCtx>();

        try
        {
            await dbCtx.Database.MigrateAsync();
            app.Logger.LogInformation("Database migrations applied successfully.");
        }
        catch (Exception ex)
        {
            app.Logger.LogError(ex, "An error occurred when applying DB migrations.");
            throw;
        }
    }
}
