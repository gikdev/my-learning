using ErrorOr;
using GymManagement.Domain.Rooms;
using MediatR;

namespace GymManagement.Application.Rooms.Commands.CreateRoom;

public record CreateRoomCommand(
    string Name,
    Guid GymId,
    int MaxDailySessions
) : IRequest<ErrorOr<Room>>;

