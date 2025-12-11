using TaskForge.Contracts.Labels;
using TaskForge.Domain.LabelAggregate;

namespace TaskForge.Api.Mappings;

public static class ToResponseMappings {
    public static LabelResponse MapToResponse(this Label label) => new() {
        Id = label.Id,
        Title = label.Title.Value,
    };
}
