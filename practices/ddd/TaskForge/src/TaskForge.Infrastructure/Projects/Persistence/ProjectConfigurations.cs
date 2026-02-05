using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskForge.Domain.ProjectAggregate;
using DomainProject = TaskForge.Domain.ProjectAggregate.Project;
using DomainTaskStatus = TaskForge.Domain.ProjectAggregate.TaskStatus;
using DomainTaskPriority = TaskForge.Domain.ProjectAggregate.TaskPriority;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TaskForge.Infrastructure.Projects.Persistence;

public class ProjectConfigurations : IEntityTypeConfiguration<DomainProject> {
    public void Configure(EntityTypeBuilder<DomainProject> builder) {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.OwnsOne(p => p.Title, title =>
            title.Property(t => t.Value)
                 .HasColumnName("Title")
                 .IsRequired());

        builder.Property(p => p.Status)
            .HasConversion(
                s => s.Name,
                name => ProjectStatus.FromName(name)
            )
            .IsRequired();

        builder.OwnsMany(p => p.Tasks, task => {
            task.WithOwner().HasForeignKey("ProjectId");
            task.HasKey(t => t.Id);
            task.Property(t => t.Id);
            task.Property(t => t.Description);

            task.OwnsOne(t => t.Title, title =>
                title.Property(t => t.Value)
                     .HasColumnName("Title")
                     .IsRequired());

            task.Property(t => t.Status)
                .HasConversion(
                    v => v.Name,
                    v => DomainTaskStatus.FromName(v)
                )
                .IsRequired();

            task.Property(t => t.Priority)
                .HasConversion(
                    v => v == null ? null : v.Name,
                    v => DomainTaskPriority.FromName(v)
                );

            task.Property<List<Guid>>("_labelIds")
                .HasColumnName("LabelIds")
                .HasConversion(
                    v => string.Join(',', v),
                    v => string.IsNullOrWhiteSpace(v)
                        ? new List<Guid>()
                        : v.Split(',').Select(Guid.Parse).ToList()
                )
                .IsRequired()
                .Metadata.SetValueComparer(
                    new ValueComparer<List<Guid>>(
                        (c1, c2) => (c1 ?? new List<Guid>()).SequenceEqual(c2 ?? new List<Guid>()),
                        c => (c ?? new List<Guid>()).Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => (c ?? new List<Guid>()).ToList()
                    )
                );
        });
    }
}
