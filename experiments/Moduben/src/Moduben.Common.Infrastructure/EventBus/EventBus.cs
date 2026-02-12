using Moduben.Common.Application.EventBus;
using MassTransit;

namespace Moduben.Common.Infrastructure.EventBus;

internal sealed class EventBus(IBus bus) : IEventBus {
    public async Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default)
        where T : IIntegrationEvent {
        await bus.Publish(integrationEvent, cancellationToken);
    }
}
