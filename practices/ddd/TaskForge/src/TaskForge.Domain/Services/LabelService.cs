using ErrorOr;
using TaskForge.Domain.Common.Interfaces;
using TaskForge.Domain.Common.ValueObjects;
using TaskForge.Domain.LabelAggregate;

namespace TaskForge.Domain.Services;

public class LabelService(ILabelsRepository labelsRepository) {
    public async Task<ErrorOr<Label>> CreateLabelAsync(
        string rawTitle,
        Guid? id = null
    ) {
        var titleOrError = NonEmptyTitle.Create(rawTitle);
        if (titleOrError.IsError) return titleOrError.Errors;

        var exists = await labelsRepository.ExistsWithTitleAsync(titleOrError.Value);
        if (exists) return LabelServiceErrors.DuplicateLabelTitle;

        return new Label(
            titleOrError.Value,
            id
        );
    }

    public async Task<ErrorOr<Label>> RenameLabelAsync(Guid labelId, string rawNewTitle) {
        var titleOrError = NonEmptyTitle.Create(rawNewTitle);
        if (titleOrError.IsError)
            return titleOrError.Errors;

        var label = await labelsRepository.GetByIdAsync(labelId);
        if (label is null)
            return LabelServiceErrors.LabelNotFound;

        var exists = await labelsRepository.ExistsWithTitleAsync(titleOrError.Value, labelId);
        if (exists)
            return LabelServiceErrors.DuplicateLabelTitle;

        label.Rename(titleOrError.Value);

        return label;
    }

    // TODO: RemoveLabelFromAllProjects(Guid labelId)
}
