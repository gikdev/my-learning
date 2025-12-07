using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainSubscriptionType = GymManagement.Domain.Subscriptions.SubscriptionType;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("subscriptions")]
public class SubscriptionsController(
    ISender mediator
) : ControllerBase {
    [HttpPost]
    public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionRequest request) {
        if (!DomainSubscriptionType.TryFromName(
                request.SubscriptionType.ToString(),
                out var subscriptionType
            ))
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: "Invalid subscription type"
            );


        var command = new CreateSubscriptionCommand(
            subscriptionType,
            request.AdminId
        );

        var result = await mediator.Send(command);

        return result.MatchFirst(
            subscription => Ok(new SubscriptionResponse(subscription.Id, request.SubscriptionType)),
            _ => Problem()
        );
    }

    [HttpGet("{subscriptionId:guid}")]
    public async Task<IActionResult> GetSubscription([FromRoute] Guid subscriptionId) {
        var query = new GetSubscriptionQuery(subscriptionId);
        var result = await mediator.Send(query);

        return result.MatchFirst(
            subscription => Ok(new SubscriptionResponse(
                subscription.Id,
                Enum.Parse<SubscriptionType>(subscription.SubscriptionType.ToString())
            )),
            _ => Problem()
        );
    }
}
