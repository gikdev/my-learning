using ErrorOr;
using TaskForge.Domain.Common;
using TaskForge.Domain.Common.ValueObjects;

namespace TaskForge.Domain.ProjectAggregate;

public class Project : AggregateRoot {
    private ProjectStatus _status;

    internal Project(
        NonEmptyTitle title,
        ProjectStatus? status = null,
        Guid? id = null
    ) : base(id ?? Guid.NewGuid()) {
        Title = title;
        _status = status ?? ProjectStatus.Active;
    }

    public List<Task> Tasks { get; } = [];

    public NonEmptyTitle Title { get; private set; }

    public bool IsCompleted => _status == ProjectStatus.Completed;
    public int TaskCount => Tasks.Count;

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

        var exists = Tasks.Any(t => NormalizeTitle(t.Title.Value) == NormalizeTitle(title));
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

        Tasks.Add(task);

        return task;
    }

    private static string NormalizeTitle(string title) {
        return title.Trim().ToLowerInvariant();
    }

    internal ErrorOr<Success> Rename(NonEmptyTitle newTitle) {
        Title = newTitle;

        return Result.Success;
    }

    public ErrorOr<Success> RemoveTask(Guid taskId) {
        var task = Tasks.FirstOrDefault(t => t.Id == taskId);
        if (task is null) return ProjectErrors.TaskNotFound;

        Tasks.Remove(task);

        return Result.Success;
    }

    public ErrorOr<Task> RenameTask(Guid taskId, string rawNewTitle) {
        var titleOrError = NonEmptyTitle.Create(rawNewTitle);
        if (titleOrError.IsError)
            return titleOrError.Errors;

        var task = Tasks.FirstOrDefault(t => t.Id == taskId);
        if (task is null)
            return ProjectErrors.TaskNotFound;

        var normalizedNewTitle = NormalizeTitle(titleOrError.Value.Value);

        var exists = Tasks.Any(t => t.Id != taskId && NormalizeTitle(t.Title.Value) == normalizedNewTitle);
        if (exists)
            return ProjectErrors.DuplicateTaskTitle;

        task.Rename(titleOrError.Value);

        return task;
    }

    public void RemoveLabelFromAllTasks(Guid labelId) {
        foreach (var task in Tasks) task.RemoveLabel(labelId);
    }
}
