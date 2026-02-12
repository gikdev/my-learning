using Ims.Common.Domain;
using Ims.Common.Presentation.Endpoints;
using Ims.Common.Presentation.Results;
using Ims.Modules.Ticketing.Application.Tickets.GetTicket;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Ims.Modules.Ticketing.Presentation.Tickets;

internal sealed class GetTicket : IEndpoint {
    public void MapEndpoint(IEndpointRouteBuilder app) {
        app.MapGet("tickets/{id}", async (Guid id, ISender sender) => {
                Result<TicketResponse> result = await sender.Send(new GetTicketQuery(id));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.GetTickets)
            .WithTags(Tags.Tickets);
    }
}
