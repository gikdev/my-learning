namespace GymManagement.Contracts.Rooms;

public record CreateRoomRequest(
    string Name,
    Guid GymId,
    int MaxDailySessions
);
