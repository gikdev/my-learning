using Moduben.Modules.Main.Application.Abstractions.Data;
using Microsoft.EntityFrameworkCore;

namespace Moduben.Modules.Main.Infrastructure.Database;

#pragma warning disable S125 // Sections of code should not be commented out
public sealed class MainDbCtx(DbContextOptions<MainDbCtx> options)
    : DbContext(options), IUnitOfWork {
    // internal DbSet<Attendee> Attendees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.HasDefaultSchema(Schemas.Main);

        // modelBuilder.ApplyConfiguration(new AttendeeConfiguration());
    }
}
