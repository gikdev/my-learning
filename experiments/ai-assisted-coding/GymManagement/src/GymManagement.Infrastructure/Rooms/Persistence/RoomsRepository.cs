using Dapper;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Rooms;
using GymManagement.Infrastructure.Common.Persistence;

namespace GymManagement.Infrastructure.Rooms.Persistence;

public class RoomsRepository(
    GymManagementDbContext db,
    IDbConnectionFactory dbConnectionFactory
) : IRoomsRepository {

    public async Task AddRoomAsync(Room room) {
        await db.AddAsync(room);
    }

    public async Task<Room?> GetByIdAsync(Guid roomId) {
        using var connection = await dbConnectionFactory.CreateConnectionAsync();

        var command = new CommandDefinition("""
            SELECT "Id", "Name", "GymId", "MaxDailySessions"
            FROM "Rooms"
            WHERE "Id" = @Id;
        """, new { Id = roomId });

        return await connection.QuerySingleOrDefaultAsync<Room>(command);
    }

    public async Task DeleteRoomAsync(Room room) {
        db.Remove(room);
        await Task.CompletedTask;
    }

    public async Task<List<Room>> ListRoomsAsync() {
        using var connection = await dbConnectionFactory.CreateConnectionAsync();

        var command = new CommandDefinition("""
            SELECT "Id", "Name", "GymId", "MaxDailySessions"
            FROM "Rooms";
        """);

        var rooms = await connection.QueryAsync<Room>(command);
        return rooms.ToList();
    }
}
