using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainSubscriptionType = GymManagement.Domain.Subscriptions.SubscriptionType;

namespace GymManagement.Api.Controllers;

/// <summary>
/// Handles all subscription-related operations.
/// </summary>
[ApiController]
[Route("subscriptions")]
public class SubscriptionsController(
    ISender mediator
) : ControllerBase {

    /// <summary>
    /// Creates a new subscription for an admin.
    /// </summary>
    /// <param name="request">The subscription details sent from the client.</param>
    /// <returns>
    /// 200 OK with the created subscription,
    /// or 400 BadRequest if the subscription type is invalid.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionRequest request) {
        // Validate subscription type (domain-level enum)
        if (!DomainSubscriptionType.TryFromName(
                request.SubscriptionType.ToString(),
                out var subscriptionType
            ))
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: "Invalid subscription type"
            );

        // Build command for application layer
        var command = new CreateSubscriptionCommand(
            subscriptionType,
            request.AdminId
        );

        var result = await mediator.Send(command);

        // Match pattern: either return the created subscription or a generic error
        return result.MatchFirst(
            subscription => Ok(new SubscriptionResponse(subscription.Id, request.SubscriptionType)),
            _ => Problem()
        );
    }

    /// <summary>
    /// Retrieves a subscription by its unique identifier.
    /// </summary>
    /// <param name="subscriptionId">The ID of the subscription to retrieve.</param>
    /// <returns>
    /// 200 OK with the subscription details,
    /// or 404/500 based on returned error.
    /// </returns>
    [HttpGet("{subscriptionId:guid}")]
    public async Task<IActionResult> GetSubscription([FromRoute] Guid subscriptionId) {
        // Create query for application layer
        var query = new GetSubscriptionQuery(subscriptionId);
        var result = await mediator.Send(query);

        // Return subscription or error result
        return result.MatchFirst(
            subscription => Ok(new SubscriptionResponse(
                subscription.Id,
                Enum.Parse<SubscriptionType>(subscription.SubscriptionType.ToString())
            )),
            _ => Problem()
        );
    }
}
