using System.Reflection;
using Ims.Modules.Ticketing.Application;
using Ims.Modules.Ticketing.Domain.Orders;
using Ims.Modules.Ticketing.Infrastructure;

namespace Ims.Modules.Ticketing.ArchitectureTests.Abstractions;

#pragma warning disable CA1515
public abstract class BaseTest {
#pragma warning restore CA1515
    protected static readonly Assembly ApplicationAssembly = typeof(AssemblyReference).Assembly;

    protected static readonly Assembly DomainAssembly = typeof(Order).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(TicketingModule).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(Ticketing.Presentation.AssemblyReference).Assembly;
}
