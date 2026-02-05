using System.ComponentModel.DataAnnotations;

namespace TaskForge.Contracts.Projects;

public record CreateProjectRequest {
    [MinLength(1)]
    public required string Title { get; init; }
    public ProjectStatus? Status { get; init; }
}
