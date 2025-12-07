using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using MediatR;

namespace GymManagement.Application.Rooms.Commands.DeleteRoom;

public class DeleteRoomCommandHandler(
    IRoomsRepository roomsRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteRoomCommand, ErrorOr<Deleted>> {
    public async Task<ErrorOr<Deleted>> Handle(
        DeleteRoomCommand request,
        CancellationToken cancellationToken
    ) {
        var room = await roomsRepository.GetByIdAsync(request.RoomId);
        
        if (room is null) {
            return Error.NotFound(description: "Room not found");
        }

        await roomsRepository.DeleteRoomAsync(room);
        await unitOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}
