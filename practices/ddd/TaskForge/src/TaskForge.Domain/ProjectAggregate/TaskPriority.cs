using Ardalis.SmartEnum;

namespace TaskForge.Domain.ProjectAggregate;

public sealed class TaskPriority : SmartEnum<TaskPriority> {
    public static readonly TaskPriority Low = new(nameof(Low), 0);
    public static readonly TaskPriority Medium = new(nameof(Medium), 1);
    public static readonly TaskPriority Hard = new(nameof(Hard), 2);

    private TaskPriority(string name, int value) : base(name, value) {
    }
}
