namespace TaskForge.Contracts.Projects;

public record ProjectResponse {
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required ProjectStatus Status { get; init; }
    // public required IEnumerable<Task> Tasks { get; init; }
}
