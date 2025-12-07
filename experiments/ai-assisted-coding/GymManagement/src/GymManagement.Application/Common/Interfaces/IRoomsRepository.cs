using GymManagement.Domain.Rooms;

namespace GymManagement.Application.Common.Interfaces;

public interface IRoomsRepository {
    Task AddRoomAsync(Room room);
    Task<Room?> GetByIdAsync(Guid roomId);
    Task DeleteRoomAsync(Room room);
    Task<List<Room>> ListRoomsAsync();
}

