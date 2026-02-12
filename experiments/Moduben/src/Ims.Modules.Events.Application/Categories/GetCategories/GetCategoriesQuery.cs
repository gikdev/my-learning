using Ims.Common.Application.Messaging;
using Ims.Modules.Events.Application.Categories.GetCategory;

namespace Ims.Modules.Events.Application.Categories.GetCategories;

public sealed record GetCategoriesQuery : IQuery<IReadOnlyCollection<CategoryResponse>>;
