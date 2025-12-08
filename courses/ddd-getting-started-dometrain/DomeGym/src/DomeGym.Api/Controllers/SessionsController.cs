using DomeGym.Api.Controllers.Common;
using DomeGym.Application.Sessions.Commands.CreateSession;
using DomeGym.Application.Sessions.Queries.GetSession;
using DomeGym.Contracts.Sessions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomeGym.Api.Controllers;

[Route("rooms/{roomId:guid}/sessions")]
public class SessionsController(ISender sender) : ApiController {
    [EndpointSummary("Create a session within a room.")]
    [HttpPost]
    public async Task<IActionResult> CreateSessionAsync(
        CreateSessionRequest request,
        Guid roomId) {
        var categoriesToDomainResult = SessionCategoryUtils.ToDomain(request.Categories);

        if (categoriesToDomainResult.IsError) return Problem(categoriesToDomainResult.Errors);

        var command = new CreateSessionCommand(
            roomId,
            request.Name,
            request.Description,
            request.MaxParticipants,
            request.StartDateTime,
            request.EndDateTime,
            request.TrainerId,
            categoriesToDomainResult.Value);

        var createSessionResult = await sender.Send(command);

        return createSessionResult.Match(
            session => CreatedAtAction(
                nameof(GetSessionAsync),
                new { roomId, SessionId = session.Id },
                new SessionResponse(
                    session.Id,
                    session.Name,
                    session.Description,
                    session.NumParticipants,
                    session.MaxParticipants,
                    session.Date.ToDateTime(session.Time.Start),
                    session.Date.ToDateTime(session.Time.End),
                    session.Categories.Select(category => category.Name).ToList())),
            Problem);
    }

    [EndpointSummary("Get details for a session in a room.")]
    [HttpGet("{sessionId:guid}")]
    public async Task<IActionResult> GetSessionAsync(
        Guid roomId,
        Guid sessionId) {
        var query = new GetSessionQuery(
            roomId,
            sessionId);

        var getSessionResult = await sender.Send(query);

        return getSessionResult.Match(
            session => Ok(new SessionResponse(
                session.Id,
                session.Name,
                session.Description,
                session.NumParticipants,
                session.MaxParticipants,
                session.Date.ToDateTime(session.Time.Start),
                session.Date.ToDateTime(session.Time.End),
                session.Categories.Select(category => category.Name).ToList())),
            Problem);
    }
}
