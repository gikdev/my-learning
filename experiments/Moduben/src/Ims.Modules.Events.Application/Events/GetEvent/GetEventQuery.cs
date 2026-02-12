using Ims.Common.Application.Messaging;

namespace Ims.Modules.Events.Application.Events.GetEvent;

public sealed record GetEventQuery(Guid EventId) : IQuery<EventResponse>;
