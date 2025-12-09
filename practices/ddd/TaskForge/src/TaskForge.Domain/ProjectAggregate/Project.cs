using ErrorOr;
using TaskForge.Domain.Common;
using TaskForge.Domain.Common.ValueObjects;

namespace TaskForge.Domain.ProjectAggregate;

public class Project : AggregateRoot {
    private readonly List<Task> _tasks = [];
    private ProjectStatus _status;
    private NonEmptyTitle _title;

    internal Project(
        NonEmptyTitle title,
        ProjectStatus? status = null,
        Guid? id = null
    ) : base(id ?? Guid.NewGuid()) {
        _title = title;
        _status = status ?? ProjectStatus.Active;
    }

    private bool IsCompleted => _status == ProjectStatus.Completed;

    public void Complete() {
        _status = ProjectStatus.Completed;
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
        if (IsCompleted)
            return ProjectErrors.CannotAddTaskToCompletedProject;

        var titleOrError = NonEmptyTitle.Create(title);
        if (titleOrError.IsError)
            return titleOrError.Errors;

        var exists = _tasks.Any(t => NormalizeTitle(t.Title.Value) == NormalizeTitle(title));
        if (exists)
            return ProjectErrors.DuplicateTaskTitle;

        var task = new Task(
            titleOrError.Value,
            status,
            id,
            labelIds,
            description,
            priority
        );

        _tasks.Add(task);

        return task;
    }

    private static string NormalizeTitle(string title) {
        return title.Trim().ToLowerInvariant();
    }

    internal ErrorOr<Success> Rename(NonEmptyTitle newTitle) {
        _title = newTitle;

        return Result.Success;
    }

    public ErrorOr<Success> RemoveTask(Guid taskId) {
        var task = _tasks.FirstOrDefault(t => t.Id == taskId);
        if (task is null) return ProjectErrors.TaskNotFound;

        _tasks.Remove(task);

        return Result.Success;
    }

    public ErrorOr<Task> RenameTask(Guid taskId, string rawNewTitle) {
        var titleOrError = NonEmptyTitle.Create(rawNewTitle);
        if (titleOrError.IsError)
            return titleOrError.Errors;

        var task = _tasks.FirstOrDefault(t => t.Id == taskId);
        if (task is null)
            return ProjectErrors.TaskNotFound;

        var normalizedNewTitle = NormalizeTitle(titleOrError.Value.Value);

        var exists = _tasks.Any(t => t.Id != taskId && NormalizeTitle(t.Title.Value) == normalizedNewTitle);
        if (exists)
            return ProjectErrors.DuplicateTaskTitle;

        task.Rename(titleOrError.Value);

        return task;
    }

    public void RemoveLabelFromAllTasks(Guid labelId) {
        foreach (var task in _tasks) task.RemoveLabel(labelId);
    }
}
