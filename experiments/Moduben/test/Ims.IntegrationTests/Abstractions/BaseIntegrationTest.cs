using Bogus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Ims.IntegrationTests.Abstractions;

[Collection(nameof(IntegrationTestCollection))]
#pragma warning disable CA1515
public abstract class BaseIntegrationTest : IDisposable {
    private readonly   IServiceScope _scope;
    protected readonly Faker         Faker = new();
    protected readonly ISender       Sender;

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory) {
        _scope = factory.Services.CreateScope();
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
    }

    public void Dispose() {
        _scope.Dispose();
    }
#pragma warning restore CA1515
}
