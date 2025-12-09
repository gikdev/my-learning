using TaskForge.Domain.Common;
using TaskForge.Domain.Common.ValueObjects;

namespace TaskForge.Domain.ProjectAggregate;

public class Task : Entity {
    private readonly List<Guid> _labelIds;
    private string? _description;
    private TaskPriority? _priority;
    private TaskStatus _status;

    internal Task(
        NonEmptyTitle title,
        TaskStatus? status = null,
        Guid? id = null,
        List<Guid>? labelIds = null,
        string? description = null,
        TaskPriority? priority = null
    ) : base(id ?? Guid.NewGuid()) {
        Title = title;

        _description = description;
        _labelIds = labelIds ?? [];
        _status = status ?? TaskStatus.Pending;
        _priority = priority;
    }

    public NonEmptyTitle Title { get; private set; }

    public IReadOnlyCollection<Guid> LabelIds => _labelIds.AsReadOnly();

    public void ToggleStatus() {
        _status = _status == TaskStatus.Pending ? TaskStatus.Completed : TaskStatus.Pending;
    }

    public void ChangeDescription(string? description) {
        _description = description;
    }

    public void ChangePriority(TaskPriority? priority) {
        _priority = priority;
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
