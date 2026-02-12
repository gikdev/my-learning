using Ims.Common.Application.Messaging;

namespace Ims.Modules.Events.Application.Categories.CreateCategory;

public sealed record CreateCategoryCommand(string Name) : ICommand<Guid>;
