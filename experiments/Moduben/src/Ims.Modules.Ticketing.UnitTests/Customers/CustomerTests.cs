using FluentAssertions;
using Ims.Common.Domain;
using Ims.Modules.Ticketing.Domain.Customers;
using Ims.Modules.Ticketing.UnitTests.Abstractions;

namespace Ims.Modules.Ticketing.UnitTests.Customers;

public class CustomerTests : BaseTest {
    [Fact]
    public void Create_ShouldReturnValue_WhenCustomerIsCreated() {
        //Act
        Result<Customer> result = Customer.Create(
            Guid.NewGuid(),
            Faker.Internet.Email(),
            Faker.Name.FirstName(),
            Faker.Name.LastName());

        //Assert
        result.Value.Should().NotBeNull();
    }
}
