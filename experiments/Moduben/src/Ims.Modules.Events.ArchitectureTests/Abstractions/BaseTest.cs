using System.Reflection;
using Ims.Modules.Events.Application;
using Ims.Modules.Events.Domain.Events;
using Ims.Modules.Events.Infrastructure;

namespace Ims.Modules.Events.ArchitectureTests.Abstractions;

#pragma warning disable CA1515
public abstract class BaseTest {
#pragma warning restore CA1515
    protected static readonly Assembly ApplicationAssembly = typeof(AssemblyReference).Assembly;

    protected static readonly Assembly DomainAssembly = typeof(Event).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(EventsModule).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(Events.Presentation.AssemblyReference).Assembly;
}
