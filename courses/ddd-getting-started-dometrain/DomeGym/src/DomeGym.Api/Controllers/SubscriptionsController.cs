using DomeGym.Application.Subscriptions.Commands.CreateSubscription;
using DomeGym.Application.Subscriptions.Queries.ListSubscriptions;
using DomeGym.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomeGym.Api.Controllers;

[Route("subscriptions")]
public class SubscriptionsController(ISender sender) : ApiController {
    [EndpointSummary("Create a subscription for an admin.")]
    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request) {
        if (!Domain.SubscriptionAggregate.SubscriptionType.TryFromName(
                request.SubscriptionType.ToString(),
                out var subscriptionType))
            return Problem("Invalid subscription type", statusCode: StatusCodes.Status400BadRequest);

        var command = new CreateSubscriptionCommand(subscriptionType, request.AdminId);

        var createSubscriptionResult = await sender.Send(command);

        return createSubscriptionResult.Match(
            subscription => Ok(new SubscriptionResponse(
                subscription.Id,
                ToDto(subscription.SubscriptionType))),
            Problem);
    }

    [EndpointSummary("List subscriptions (temporary all tenants).")]
    [HttpGet]
    public async Task<IActionResult> ListSubscriptions() {
        // TODO: get user/admin id from token, for now, return all
        var query = new ListSubscriptionsQuery();

        var listSubscriptionsResult = await sender.Send(query);

        return listSubscriptionsResult.Match(
            subscriptions => Ok(subscriptions.ConvertAll(subscription => new SubscriptionResponse(
                subscription.Id,
                ToDto(subscription.SubscriptionType)))),
            Problem);
    }

    private static SubscriptionType ToDto(Domain.SubscriptionAggregate.SubscriptionType subscriptionType) {
        return subscriptionType.Name switch {
            nameof(Domain.SubscriptionAggregate.SubscriptionType.Free) => SubscriptionType.Free,
            nameof(Domain.SubscriptionAggregate.SubscriptionType.Starter) => SubscriptionType.Starter,
            nameof(Domain.SubscriptionAggregate.SubscriptionType.Pro) => SubscriptionType.Pro,
            _ => throw new InvalidOperationException()
        };
    }
}
