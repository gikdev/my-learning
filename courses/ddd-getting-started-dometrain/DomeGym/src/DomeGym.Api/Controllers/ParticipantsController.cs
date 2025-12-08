using DomeGym.Application.Participants.Commands.CancelReservation;
using DomeGym.Application.Participants.Queries.ListParticipantSessions;
using DomeGym.Application.Reservations.Commands.CreateReservation;
using DomeGym.Contracts.Sessions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomeGym.Api.Controllers;

[Route("participants")]
public class ParticipantsController(ISender sender) : ApiController {
    [EndpointSummary("List sessions for a participant with optional dates.")]
    [HttpGet("{participantId:guid}/sessions")]
    public async Task<IActionResult> ListParticipantSessionsAsync(
        Guid participantId,
        DateTime? startDateTime = null,
        DateTime? endDateTime = null) {
        var query = new ListParticipantSessionsQuery(
            participantId,
            startDateTime,
            endDateTime);

        var listParticipantSessionsResult = await sender.Send(query);

        return listParticipantSessionsResult.Match(
            sessions => Ok(sessions.ConvertAll(session => new SessionResponse(
                session.Id,
                session.Name,
                session.Description,
                session.NumParticipants,
                session.MaxParticipants,
                session.Date.ToDateTime(session.Time.Start),
                session.Date.ToDateTime(session.Time.End),
                session.Categories.Select(category => category.Name).ToList()))),
            Problem);
    }

    [EndpointSummary("Cancel a participant's reservation for a session.")]
    [HttpDelete("{participantId:guid}/sessions/{sessionId:guid}/reservation")]
    public async Task<IActionResult> CancelReservationAsync(
        Guid participantId,
        Guid sessionId) {
        var command = new CancelReservationCommand(participantId, sessionId);

        var cancelReservationResult = await sender.Send(command);

        return cancelReservationResult.Match(
            _ => NoContent(),
            Problem);
    }

    [EndpointSummary("Create a reservation for a participant and session.")]
    [HttpPost("{participantId:guid}/sessions/{sessionId:guid}/reservation")]
    public async Task<IActionResult> CreateReservationAsync(
        Guid participantId,
        Guid sessionId) {
        var command = new CreateReservationCommand(sessionId, participantId);

        var cancelReservationResult = await sender.Send(command);

        return cancelReservationResult.Match(
            _ => NoContent(),
            Problem);
    }
}
