using ErrorOr;
using TaskForge.Domain.Common;
using TaskForge.Domain.Common.ValueObjects;

namespace TaskForge.Domain.ProjectAggregate;

public class Project : AggregateRoot {
    #pragma warning disable CS8618
    private Project() {}
    #pragma warning restore CS8618

    internal Project(
        NonEmptyTitle title,
        ProjectStatus? status = null,
        Guid? id = null
    ) : base(id ?? Guid.NewGuid()) {
        Title = title;
        Status = status ?? ProjectStatus.Active;
    }

    public ProjectStatus Status { get; private set; }
    public List<Task> Tasks { get; private set; } = [];
    public NonEmptyTitle Title { get; private set; }

    public bool IsCompleted => Status == ProjectStatus.Completed;
    public int TaskCount => Tasks.Count;

    public void Complete() {
        Status = ProjectStatus.Completed;
    }

    public void Activate() {
        Status = ProjectStatus.Active;
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
