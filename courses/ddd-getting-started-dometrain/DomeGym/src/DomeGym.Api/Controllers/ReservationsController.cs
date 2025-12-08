using DomeGym.Application.Reservations.Commands.CreateReservation;
using DomeGym.Contracts.Reservations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomeGym.Api.Controllers;

[Route("sessions/{sessionId:guid}/reservations")]
public class ReservationsController(ISender sender) : ApiController {
    [EndpointSummary("Create a reservation for a session.")]
    [HttpPost]
    public async Task<IActionResult> CreateReservationAsync(
        CreateReservationRequest request,
        Guid sessionId) {
        var command = new CreateReservationCommand(
            sessionId,
            request.ParticipantId);

        var createReservationResult = await sender.Send(command);

        return createReservationResult.Match(_ => NoContent(), Problem);
    }
}
