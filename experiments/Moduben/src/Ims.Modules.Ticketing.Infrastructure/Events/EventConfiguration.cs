using Ims.Modules.Ticketing.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Modules.Ticketing.Infrastructure.Events;

internal sealed class EventConfiguration : IEntityTypeConfiguration<Event> {
    public void Configure(EntityTypeBuilder<Event> builder) {
        builder.HasKey(e => e.Id);
    }
}
