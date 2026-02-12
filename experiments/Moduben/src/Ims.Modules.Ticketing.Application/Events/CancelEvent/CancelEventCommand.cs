using Ims.Common.Application.Messaging;

namespace Ims.Modules.Ticketing.Application.Events.CancelEvent;

public sealed record CancelEventCommand(Guid EventId) : ICommand;
