using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Rooms;
using MediatR;

namespace GymManagement.Application.Rooms.Commands.CreateRoom;

public class CreateRoomCommandHandler(
    IRoomsRepository roomsRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<CreateRoomCommand, ErrorOr<Room>> {
    public async Task<ErrorOr<Room>> Handle(
        CreateRoomCommand request,
        CancellationToken cancellationToken
    ) {
        var room = new Room(
            name: request.Name,
            gymId: request.GymId,
            maxDailySessions: request.MaxDailySessions
        );

        await roomsRepository.AddRoomAsync(room);
        await unitOfWork.CommitChangesAsync();

        return room;
    }
}

