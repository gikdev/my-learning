using GymManagement.Contracts.Subscriptions;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("subscriptions")]
public class SubscriptionsController : ControllerBase {
    [HttpPost]
    public IActionResult CreateSubscription([FromBody] CreateSubscriptionRequest request) {
        return Ok(request);
    }
}
