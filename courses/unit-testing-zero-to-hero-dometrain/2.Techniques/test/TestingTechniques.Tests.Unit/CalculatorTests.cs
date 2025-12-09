using FluentAssertions;
using Xunit.Abstractions;

namespace TestingTechniques.Tests.Unit;

public class CalculatorTests
// :IAsyncLifetime
{
    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly ITestOutputHelper _outputHelper;
    private readonly Calculator _sut = new();

    // ctor is always first then it's InitializeAsync!
    public CalculatorTests(ITestOutputHelper outputHelper) {
        _outputHelper = outputHelper;
        _outputHelper.WriteLine("Hello from Ctor!");
    }

    [Theory]
    [
        InlineData(1, 2, 3),
        InlineData(5, 4, 9),
        InlineData(0, 0, 0, Skip = "Because this is a really stupid thing to test!"),
        InlineData(-5, -5, -10),
    ]
    public void Add_ShouldAddTwoNumbers_WhenTwoNumbersAreIntegers(
        int a, int b, int expected
    ) {
        // Act
        var result = _sut.Add(a, b);

        // Assert
        result.Should().Be(expected);
    }

    [Fact(Skip = "Because we have more important tests to write...")]
    public void Subtract_ShouldSubtractTwoNumbers_WhenTwoNumbersAreIntegers() {
        // Act
        var result = _sut.Subtract(3, 2);

        // Assert
        result.Should().Be(1);
    }

    // Keep AAA comments.

    // public async Task InitializeAsync() {
    //     _outputHelper.WriteLine("Hello from InitializeAsync!");
    // }
    //
    // public async Task DisposeAsync() {
    //     _outputHelper.WriteLine("Hello from DisposeAsync!");
    // }
}
