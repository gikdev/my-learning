using System.ComponentModel.DataAnnotations;

namespace Contracts.Categories;

public record RenameCategoryRequest {
    [MinLength(1)]
    public required string NewTitle { get; init; }
}
