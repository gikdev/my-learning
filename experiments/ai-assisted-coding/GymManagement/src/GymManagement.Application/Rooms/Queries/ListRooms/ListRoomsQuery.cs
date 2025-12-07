using ErrorOr;
using GymManagement.Domain.Rooms;
using MediatR;

namespace GymManagement.Application.Rooms.Queries.ListRooms;

public record ListRoomsQuery() : IRequest<ErrorOr<List<Room>>>;

