using Ims.Common.Application.Messaging;
using Ims.Modules.Events.Application.TicketTypes.GetTicketType;

namespace Ims.Modules.Events.Application.TicketTypes.GetTicketTypes;

public sealed record GetTicketTypesQuery(Guid EventId) : IQuery<IReadOnlyCollection<TicketTypeResponse>>;
