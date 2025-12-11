using System.ComponentModel.DataAnnotations;

namespace Contracts.Categories;

public record CreateCategoryRequest {
    [MinLength(1)]
    public required string Title { get; init; }
};
