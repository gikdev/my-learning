using TaskForge.Domain.Common;
using TaskForge.Domain.Common.ValueObjects;

namespace TaskForge.Domain.ProjectAggregate;

public class Task : Entity {
    private readonly List<Guid> _labelIds;

    #pragma warning disable CS8618
    private Task() {}
    #pragma warning restore CS8618

    internal Task(
        NonEmptyTitle title,
        TaskStatus? status = null,
        Guid? id = null,
        List<Guid>? labelIds = null,
        string? description = null,
        TaskPriority? priority = null
    ) : base(id ?? Guid.NewGuid()) {
        Title = title;

        Description = description;
        _labelIds = labelIds ?? [];
        Status = status ?? TaskStatus.Pending;
        Priority = priority;
    }

    public string? Description { get; private set; }
    public TaskStatus Status { get; private set; }
    public TaskPriority? Priority { get; private set; }

    public NonEmptyTitle Title { get; private set; }

    public IReadOnlyCollection<Guid> LabelIds => _labelIds.AsReadOnly();

    public void ToggleStatus() {
        Status = Status == TaskStatus.Pending ? TaskStatus.Completed : TaskStatus.Pending;
    }

    public void ChangeDescription(string? description) {
        Description = description;
    }

    public void ChangePriority(TaskPriority? priority) {
        Priority = priority;
    }

    public void Rename(NonEmptyTitle newTitle) {
        Title = newTitle;
    }

    public void AddLabel(Guid labelId) {
        if (_labelIds.Contains(labelId)) return;
        _labelIds.Add(labelId);
    }

    public void RemoveLabel(Guid labelId) {
        _labelIds.Remove(labelId);
    }
}
