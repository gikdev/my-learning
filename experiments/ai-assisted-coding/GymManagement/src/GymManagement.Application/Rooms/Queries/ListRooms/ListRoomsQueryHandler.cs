using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Rooms;
using MediatR;

namespace GymManagement.Application.Rooms.Queries.ListRooms;

public class ListRoomsQueryHandler(
    IRoomsRepository roomsRepository
) : IRequestHandler<ListRoomsQuery, ErrorOr<List<Room>>> {
    public async Task<ErrorOr<List<Room>>> Handle(ListRoomsQuery request, CancellationToken cancellationToken) {
        var rooms = await roomsRepository.ListRoomsAsync();
        return rooms;
    }
}

