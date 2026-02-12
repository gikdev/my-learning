using Ims.Common.Application.Messaging;

namespace Ims.Modules.Events.Application.Events.CancelEvent;

public sealed record CancelEventCommand(Guid EventId) : ICommand;
