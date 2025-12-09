using Ardalis.SmartEnum;

namespace TaskForge.Domain.ProjectAggregate;

public sealed class TaskStatus : SmartEnum<TaskStatus> {
    public static readonly TaskStatus Pending = new(nameof(Pending), 0);
    public static readonly TaskStatus Completed = new(nameof(Completed), 1);

    private TaskStatus(string name, int value) : base(name, value) {
    }
}
