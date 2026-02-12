using System.Security.Claims;
using Ims.Common.Domain;
using Ims.Common.Infrastructure.Authentication;
using Ims.Common.Presentation.Endpoints;
using Ims.Common.Presentation.Results;
using Ims.Modules.Users.Application.Users.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Ims.Modules.Users.Presentation.Users;

internal sealed class UpdateUserProfile : IEndpoint {
    public void MapEndpoint(IEndpointRouteBuilder app) {
        app.MapPut("users/profile", async (Request request, ClaimsPrincipal claims, ISender sender) => {
                Result result = await sender.Send(new UpdateUserCommand(
                    claims.GetUserId(),
                    request.FirstName,
                    request.LastName));

                return result.Match(Results.NoContent, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.ModifyUser)
            .WithTags(Tags.Users);
    }

    internal sealed class Request {
        public string FirstName { get; init; }

        public string LastName { get; init; }
    }
}
