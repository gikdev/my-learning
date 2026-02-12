using System.Reflection;
using Ims.Modules.Users.Application;
using Ims.Modules.Users.Domain.Users;
using Ims.Modules.Users.Infrastructure;

namespace Ims.Modules.Users.ArchitectureTests.Abstractions;

#pragma warning disable CA1515
public abstract class BaseTest {
#pragma warning restore CA1515
    protected static readonly Assembly ApplicationAssembly = typeof(AssemblyReference).Assembly;

    protected static readonly Assembly DomainAssembly = typeof(User).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(UsersModule).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(Users.Presentation.AssemblyReference).Assembly;
}
