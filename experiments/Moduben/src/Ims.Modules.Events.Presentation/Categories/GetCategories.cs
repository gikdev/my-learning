using Ims.Common.Domain;
using Ims.Common.Presentation.Endpoints;
using Ims.Common.Presentation.Results;
using Ims.Modules.Events.Application.Categories.GetCategories;
using Ims.Modules.Events.Application.Categories.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Ims.Modules.Events.Presentation.Categories;

internal sealed class GetCategories : IEndpoint {
    public void MapEndpoint(IEndpointRouteBuilder app) {
        app.MapGet("categories", async (ISender sender) => {
                Result<IReadOnlyCollection<CategoryResponse>> result = await sender.Send(new GetCategoriesQuery());

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.GetCategories)
            .WithTags(Tags.Categories);
    }
}
