using ErrorOr;

namespace TaskForge.Domain.ProjectAggregate;

public static class ProjectErrors {
    public static readonly Error CannotAddTaskToCompletedProject = Error.Conflict(
        "Project.CannotAddTaskToCompletedProject",
        "Cannot add new task to completed project."
    );

    public static readonly Error DuplicateTaskTitle = Error.Conflict(
        "Project.DuplicateTaskTitle",
        "Task title must be unique within the project."
    );

    public static readonly Error TaskNotFound = Error.NotFound(
        "Project.TaskNotFound",
        "Task not found."
    );
}
