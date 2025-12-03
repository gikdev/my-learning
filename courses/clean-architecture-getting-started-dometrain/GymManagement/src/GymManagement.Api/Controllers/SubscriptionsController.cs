using GymManagement.Application.Services;
using GymManagement.Contracts.Subscriptions;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("subscriptions")]
public class SubscriptionsController(ISubscriptionsService subscriptionsService) : ControllerBase {
    [HttpPost]
    public IActionResult CreateSubscription([FromBody] CreateSubscriptionRequest request) {
        var subscriptionId = subscriptionsService.CreateSubscription(
            request.SubscriptionType.ToString(),
            request.AdminId
        );
       
        var response = new SubscriptionResponse(subscriptionId, request.SubscriptionType);

        return Ok(response);
    }
}
