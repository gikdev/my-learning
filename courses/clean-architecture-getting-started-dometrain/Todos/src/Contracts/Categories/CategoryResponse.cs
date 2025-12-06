namespace Contracts.Categories;

public record CategoryResponse {
    public required Guid Id { get; init; }
    public required string Title { get; init; }
};
