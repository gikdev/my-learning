using GymManagement.Application.Rooms.Commands.CreateRoom;
using GymManagement.Application.Rooms.Commands.DeleteRoom;
using GymManagement.Application.Rooms.Queries.GetRoom;
using GymManagement.Application.Rooms.Queries.ListRooms;
using GymManagement.Contracts.Rooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("rooms")]
public class RoomsController(
    ISender mediator
) : ControllerBase {
    [HttpPost]
    public async Task<IActionResult> CreateRoom([FromBody] CreateRoomRequest request) {
        var command = new CreateRoomCommand(
            request.Name,
            request.GymId,
            request.MaxDailySessions
        );

        var result = await mediator.Send(command);

        return result.MatchFirst(
            room => Ok(new RoomResponse(room.Id, room.Name)),
            _ => Problem()
        );
    }

    [HttpGet]
    public async Task<IActionResult> ListRooms() {
        var query = new ListRoomsQuery();
        var result = await mediator.Send(query);

        return result.MatchFirst(
            rooms => Ok(rooms.Select(r => new RoomResponse(r.Id, r.Name))),
            _ => Problem()
        );
    }

    [HttpGet("{roomId:guid}")]
    public async Task<IActionResult> GetRoom([FromRoute] Guid roomId) {
        var query = new GetRoomQuery(roomId);
        var result = await mediator.Send(query);

        return result.MatchFirst(
            room => Ok(new RoomResponse(room.Id, room.Name)),
            _ => Problem()
        );
    }

    [HttpDelete("{roomId:guid}")]
    public async Task<IActionResult> DeleteRoom([FromRoute] Guid roomId) {
        var command = new DeleteRoomCommand(roomId);
        var result = await mediator.Send(command);

        return result.MatchFirst<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }
}

