using FluentAssertions;
using NetArchTest.Rules;

namespace Ims.Modules.Events.ArchitectureTests.Abstractions;

internal static class TestResultExtensions {
    internal static void ShouldBeSuccessful(this TestResult testResult) {
        testResult.FailingTypes?.Should().BeEmpty();
    }
}
