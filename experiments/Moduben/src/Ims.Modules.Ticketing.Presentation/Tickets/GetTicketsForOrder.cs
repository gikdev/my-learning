using Ims.Common.Domain;
using Ims.Common.Presentation.Endpoints;
using Ims.Common.Presentation.Results;
using Ims.Modules.Ticketing.Application.Tickets.GetTicket;
using Ims.Modules.Ticketing.Application.Tickets.GetTicketForOrder;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Ims.Modules.Ticketing.Presentation.Tickets;

internal sealed class GetTicketsForOrder : IEndpoint {
    public void MapEndpoint(IEndpointRouteBuilder app) {
        app.MapGet("tickets/order/{orderId}", async (Guid orderId, ISender sender) => {
                Result<IReadOnlyCollection<TicketResponse>> result = await sender.Send(
                    new GetTicketsForOrderQuery(orderId));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.GetTickets)
            .WithTags(Tags.Tickets);
    }
}
