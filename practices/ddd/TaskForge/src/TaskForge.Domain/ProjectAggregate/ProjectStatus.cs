using Ardalis.SmartEnum;

namespace TaskForge.Domain.ProjectAggregate;

public sealed class ProjectStatus : SmartEnum<ProjectStatus> {
    public static readonly ProjectStatus Active = new(nameof(Active), 0);
    public static readonly ProjectStatus Completed = new(nameof(Completed), 1);

    private ProjectStatus(string name, int value) : base(name, value) {
    }
}
