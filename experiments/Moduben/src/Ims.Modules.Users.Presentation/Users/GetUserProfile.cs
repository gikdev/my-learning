using System.Security.Claims;
using Ims.Common.Domain;
using Ims.Common.Infrastructure.Authentication;
using Ims.Common.Presentation.Endpoints;
using Ims.Common.Presentation.Results;
using Ims.Modules.Users.Application.Users.GetUser;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Ims.Modules.Users.Presentation.Users;

internal sealed class GetUserProfile : IEndpoint {
    public void MapEndpoint(IEndpointRouteBuilder app) {
        app.MapGet("users/profile", async (ClaimsPrincipal claims, ISender sender) => {
                Result<UserResponse> result = await sender.Send(new GetUserQuery(claims.GetUserId()));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.GetUser)
            .WithTags(Tags.Users);
    }
}
