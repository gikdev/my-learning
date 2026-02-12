using Bogus;
using Ims.Modules.Events.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ims.Modules.Events.IntegrationTests.Abstractions;

[Collection(nameof(IntegrationTestCollection))]
#pragma warning disable CA1515
public abstract class BaseIntegrationTest : IDisposable {
#pragma warning restore CA1515
    protected static readonly Faker                        Faker = new();
    private readonly          IServiceScope                _scope;
    protected readonly        EventsDbContext              DbContext;
    protected readonly        IntegrationTestWebAppFactory Factory;
    protected readonly        ISender                      Sender;

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory) {
        _scope    = factory.Services.CreateScope();
        Factory   = factory;
        Sender    = _scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = _scope.ServiceProvider.GetRequiredService<EventsDbContext>();
    }

    public void Dispose() {
        _scope.Dispose();
    }

    protected async Task CleanDatabaseAsync() {
        await DbContext.Database.ExecuteSqlRawAsync(
            """
            DELETE FROM events.inbox_message_consumers;
            DELETE FROM events.inbox_messages;
            DELETE FROM events.outbox_message_consumers;
            DELETE FROM events.outbox_messages;
            DELETE FROM events.ticket_types;
            DELETE FROM events.events;
            DELETE FROM events.categories;
            """);
    }
}
