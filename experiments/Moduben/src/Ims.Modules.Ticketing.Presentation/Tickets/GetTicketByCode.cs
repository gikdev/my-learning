using Ims.Common.Domain;
using Ims.Common.Presentation.Endpoints;
using Ims.Common.Presentation.Results;
using Ims.Modules.Ticketing.Application.Tickets.GetTicket;
using Ims.Modules.Ticketing.Application.Tickets.GetTicketByCode;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Ims.Modules.Ticketing.Presentation.Tickets;

internal sealed class GetTicketByCode : IEndpoint {
    public void MapEndpoint(IEndpointRouteBuilder app) {
        app.MapGet("tickets/code/{code}", async (string code, ISender sender) => {
                Result<TicketResponse> result = await sender.Send(new GetTicketByCodeQuery(code));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.GetTickets)
            .WithTags(Tags.Tickets);
    }
}
