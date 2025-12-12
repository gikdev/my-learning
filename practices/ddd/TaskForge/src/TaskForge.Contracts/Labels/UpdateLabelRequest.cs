using System.ComponentModel.DataAnnotations;

namespace TaskForge.Contracts.Labels;

public record UpdateLabelRequest {
    [MinLength(1)]
    public required string Title { get; init; }
}
