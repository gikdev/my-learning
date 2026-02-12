using Ims.Common.Application.Messaging;

namespace Ims.Modules.Events.Application.Events.PublishEvent;

public sealed record PublishEventCommand(Guid EventId) : ICommand;
