using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Rooms;
using MediatR;

namespace GymManagement.Application.Rooms.Queries.GetRoom;

public class GetRoomQueryHandler(
    IRoomsRepository roomsRepository
) : IRequestHandler<GetRoomQuery, ErrorOr<Room>> {
    public async Task<ErrorOr<Room>> Handle(GetRoomQuery request, CancellationToken cancellationToken) {
        var room = await roomsRepository.GetByIdAsync(request.RoomId);
        return room is null ? Error.NotFound(description: "Room not found") : room;
    }
}

