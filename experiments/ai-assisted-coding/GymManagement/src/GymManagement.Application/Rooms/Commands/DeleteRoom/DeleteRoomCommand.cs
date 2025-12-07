using ErrorOr;
using MediatR;

namespace GymManagement.Application.Rooms.Commands.DeleteRoom;

public record DeleteRoomCommand(
    Guid RoomId
) : IRequest<ErrorOr<Deleted>>;

