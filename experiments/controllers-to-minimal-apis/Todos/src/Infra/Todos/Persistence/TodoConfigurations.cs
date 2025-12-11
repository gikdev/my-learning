using Domain.Todos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Todos.Persistence;

public class TodoConfigurations : IEntityTypeConfiguration<Todo> {
    public void Configure(EntityTypeBuilder<Todo> builder) {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedNever();

        builder.Property(t => t.Importance)
            .HasConversion(
                importance => importance.Value,
                value => TodoImportance.FromValue(value)
            );
    }
}
