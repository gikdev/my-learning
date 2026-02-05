using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskForge.Domain.LabelAggregate;

namespace TaskForge.Infrastructure.Labels.Persistence;

public class LabelConfigurations : IEntityTypeConfiguration<Label> {
    public void Configure(EntityTypeBuilder<Label> builder) {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
            .ValueGeneratedNever();

        builder.OwnsOne(l => l.Title, title =>
            title.Property(t => t.Value)
                 .HasColumnName("Title")
                 .IsRequired());
    }
}
