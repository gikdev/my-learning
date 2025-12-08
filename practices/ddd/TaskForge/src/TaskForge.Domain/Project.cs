using ErrorOr;
using TaskForge.Domain.Common;

namespace TaskForge.Domain;

public class Project : Entity {
    private readonly string _title;
    private ProjectStatus _status;
    public bool IsArchived => _status == ProjectStatus.Archived;

    public Project(
        string title,
        ProjectStatus? status = null,
        Guid? id = null
    ) : base(id ?? Guid.NewGuid()) {
        _title = title;
        _status = status ?? ProjectStatus.Active;
    }

    public void Archive() {
        _status = ProjectStatus.Archived;
    }

    public void Activate() {
        _status = ProjectStatus.Active;
    }

    public ErrorOr<Task> AddTask(
        string title,
        TaskStatus? status = null,
        Guid? id = null,
        List<Guid>? labelIds = null,
        string? description = null,
        TaskPriority? priority = null
    ) {
        if (IsArchived) return ProjectErrors.CantAddTaskWhenProjectIsArchived;

        return new Task(
            title: title,
            projectId: Id,
            status: status,
            id: id,
            labelIds: labelIds,
            description: description,
            priority: priority
        );
    }
}
