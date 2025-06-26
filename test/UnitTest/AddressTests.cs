using HexagonalTemplate.Core.Domain.Modules.Accounts.ValueObjects;

namespace UnitTest;

public class AddressTests
{
    [Theory]
    [InlineData("123 Main St", "Springfield", "IL", "62701", "USA", 123, "Apt 4B")]
    public void Should_Create_Address(string street, string city, string state, string zipCode, string country, int? number, string? complement)
    {
        var address = new Address(street, city, state, zipCode, country, number, complement);
        
        Assert.Equal(street, address.Street);
        Assert.Equal(city, address.City);
        Assert.Equal(state, address.State);
        Assert.Equal(zipCode, address.ZipCode);
        Assert.Equal(country, address.Country);
        Assert.Equal(number, address.Number);
        Assert.Equal(complement, address.Complement);   
    }
}