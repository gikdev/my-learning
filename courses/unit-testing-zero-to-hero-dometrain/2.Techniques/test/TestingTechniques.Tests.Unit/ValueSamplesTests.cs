using FluentAssertions;

namespace TestingTechniques.Tests.Unit;

public class ValueSamplesTests {
    private readonly ValueSamples _sut = new();

    [Fact]
    public void StringAssertionExample() {
        var fullname = _sut.FullName;

        fullname.Should().Be("Nick Chapsas");
        fullname.Should().NotBeEmpty();
        fullname.Should().StartWith("Nick");
        fullname.Should().EndWith("Chapsas");
    }

    [Fact]
    public void NumberAssertionExample() {
        var age = _sut.Age;

        age.Should().Be(21);
        age.Should().BePositive();
        age.Should().BeGreaterThan(10);
        age.Should().BeInRange(10, 30);
    }

    [Fact]
    public void DateAssertionExample() {
        var dateOfBirth = _sut.DateOfBirth;

        var myBirth = new DateOnly(2007, 1, 17);

        dateOfBirth.Should().Be(new(2000, 6, 9));
        dateOfBirth.Should().NotBe(myBirth);
    }

    [Fact]
    public void ObjectAssertionExample() {
        var expected = new User {
            FullName = "Nick Chapsas",
            Age = 21,
            DateOfBirth = new(2000, 6, 9)
        };

        var user = _sut.AppUser;

        // user.Should().Be(expected);
        user.Should().BeEquivalentTo(expected);

    }

    [Fact]
    public void EnumerableObjectsAssertionExample() {
        var expected = new User {
            FullName = "Nick Chapsas",
            Age = 21,
            DateOfBirth = new(2000, 6, 9)
        };

        var users = _sut.Users.As<User[]>();

        users.Should().ContainEquivalentOf(expected);
        users.Should().HaveCount(3);
        users.Should().Contain(x => x.FullName.StartsWith("Nick") && x.Age > 5);
    }

    [Fact]
    public void ExceptionThrownAssertionExample() {
        var calculator = new Calculator();

        var action = () => calculator.Divide(1, 0);

        action.Should().Throw<DivideByZeroException>();
    }

    [Fact]
    public void EventRaisedAssertionExample() {
        var monitorSubject = _sut.Monitor();

        _sut.RaiseExampleEvent();

        monitorSubject.Should().Raise("ExampleEvent");
    }

    [Fact]
    public void TestingInternalMembersExample() {
        var num = _sut.InternalSecretNumber;
    }
}
