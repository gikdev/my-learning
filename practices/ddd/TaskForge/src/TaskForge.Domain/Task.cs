using TaskForge.Domain.Common;

namespace TaskForge.Domain;

public class Task : Entity {
    // Core identity and association
    private readonly Guid _projectId;

    // Task details
    private readonly string _title;
    private readonly string? _description;
    private readonly TaskPriority? _priority;

    // Task state
    private readonly TaskStatus _status;
    private readonly List<Guid> _labelIds;

    // Constructor
    public Task(
        string title,
        Guid projectId,
        TaskStatus? status = null,
        Guid? id = null,
        List<Guid>? labelIds = null,
        string? description = null,
        TaskPriority? priority = null
    ) : base(id ?? Guid.NewGuid()) {
        _title = title;
        _projectId = projectId;

        _description = description;
        _labelIds = labelIds ?? [];
        _status = status ?? TaskStatus.Pending;
        _priority = priority;
    }
}
