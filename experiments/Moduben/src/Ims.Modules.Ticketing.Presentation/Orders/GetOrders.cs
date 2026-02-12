using Ims.Common.Domain;
using Ims.Common.Presentation.Endpoints;
using Ims.Common.Presentation.Results;
using Ims.Modules.Ticketing.Application.Abstractions.Authentication;
using Ims.Modules.Ticketing.Application.Orders.GetOrders;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Ims.Modules.Ticketing.Presentation.Orders;

internal sealed class GetOrders : IEndpoint {
    public void MapEndpoint(IEndpointRouteBuilder app) {
        app.MapGet("orders", async (ICustomerContext customerContext, ISender sender) => {
                Result<IReadOnlyCollection<OrderResponse>> result = await sender.Send(
                    new GetOrdersQuery(customerContext.CustomerId));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.GetOrders)
            .WithTags(Tags.Orders);
    }
}
