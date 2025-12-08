using DomeGym.Application.Rooms.Commands.CreateRoom;
using DomeGym.Application.Rooms.Commands.DeleteRoom;
using DomeGym.Application.Rooms.Queries.GetRoom;
using DomeGym.Application.Rooms.Queries.ListRooms;
using DomeGym.Contracts.Rooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomeGym.Api.Controllers;

[Route("gyms/{gymId:guid}/rooms")]
public class RoomsController(ISender sender) : ApiController {
    [EndpointSummary("Create a new room within the specified gym.")]
    [HttpPost]
    public async Task<IActionResult> CreateRoom(
        CreateRoomRequest request,
        Guid gymId) {
        var command = new CreateRoomCommand(
            gymId,
            request.Name);

        var createRoomResult = await sender.Send(command);

        return createRoomResult.Match(
            room => CreatedAtAction(
                nameof(GetRoom),
                new { gymId, RoomId = room.Id },
                new RoomResponse(room.Id, room.Name)),
            Problem);
    }

    [EndpointSummary("Delete a room from a gym.")]
    [HttpDelete("{roomId:guid}")]
    public async Task<IActionResult> DeleteRoom(
        Guid gymId,
        Guid roomId) {
        var command = new DeleteRoomCommand(gymId, roomId);

        var deleteRoomResult = await sender.Send(command);

        return deleteRoomResult.Match(_ => NoContent(), Problem);
    }

    [EndpointSummary("Get details for a room in a gym.")]
    [HttpGet("{roomId:guid}")]
    public async Task<IActionResult> GetRoom(
        Guid gymId,
        Guid roomId) {
        var query = new GetRoomQuery(gymId, roomId);

        var getRoomResult = await sender.Send(query);

        return getRoomResult.Match(
            room => Ok(new RoomResponse(room.Id, room.Name)),
            Problem);
    }

    [EndpointSummary("List all rooms belonging to a gym.")]
    [HttpGet]
    public async Task<IActionResult> ListRooms(Guid gymId) {
        var query = new ListRoomsQuery(gymId);

        var listRoomsResult = await sender.Send(query);

        return listRoomsResult.Match(
            rooms => Ok(rooms.ConvertAll(room => new RoomResponse(room.Id, room.Name))),
            Problem);
    }
}
