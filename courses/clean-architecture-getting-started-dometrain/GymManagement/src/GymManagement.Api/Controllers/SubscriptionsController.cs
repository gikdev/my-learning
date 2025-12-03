using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("subscriptions")]
public class SubscriptionsController(
    ISender mediator
) : ControllerBase {
    [HttpPost]
    public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionRequest request) {
        var command = new CreateSubscriptionCommand(
            request.SubscriptionType.ToString(),
            request.AdminId
        );

        var response = await mediator.Send(command);

        return Ok(response);
    }
}
