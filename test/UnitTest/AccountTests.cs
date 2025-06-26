using HexagonalTemplate.Core.Domain.Modules.Accounts.Aggregates;

namespace UnitTest;

public class AccountTests
{
    [Theory]
    [InlineData("João", "Silva", "joao@email.com")]
    public void Create_Should_Set_Profile_And_Id(string firstName, string lastName, string email)
    {
        var account = new Account();

        account.Create(firstName, lastName, email);

        Assert.NotEqual(Guid.Empty, account.Id);
        Assert.NotNull(account.Profile);
        Assert.Equal(firstName, account.Profile.FirstName);
        Assert.Equal(lastName, account.Profile.LastName);
        Assert.Equal(email, account.Profile.Email);
    }
    
    [Theory]
    [InlineData("", "Silva", "joao@email.com")]
    [InlineData("João", "", "joao@email.com")]
    [InlineData("João", "Silva", "")]
    public void Create_Should_Throw_When_Arguments_Are_Invalid(string firstName, string lastName, string email)
    {
        var account = new Account();

        Assert.Throws<ArgumentException>(() =>
        {
            account.Create(firstName, lastName, email);
        });
    }
    
    [Theory]
    [InlineData("Rua A", "Cidade B", "Estado C", "12345-678", "Brasil", 123, "Apto 1")]
    public void InformAddress_Should_Define_Address_Correctly(string street, string city, string state, string zipCode, string country, int? number, string? complement)
    {
        var account = new Account();

        account.InformAddress(street, city, state, zipCode, country, number, complement);

        Assert.NotNull(account.Address);
        Assert.Equal(street, account.Address.Street);
        Assert.Equal(city, account.Address.City);
        Assert.Equal(state, account.Address.State);
        Assert.Equal(zipCode, account.Address.ZipCode);
        Assert.Equal(country, account.Address.Country);
        Assert.Equal(number, account.Address.Number);
        Assert.Equal(complement, account.Address.Complement);
    }

    [Theory]
    [InlineData("", "Cidade", "Estado", "12345-678", "Brasil", 100, null)]
    [InlineData("Rua", "", "Estado", "12345-678", "Brasil", 100, null)]
    [InlineData("Rua", "Cidade", "", "12345-678", "Brasil", 100, null)]
    [InlineData("Rua", "Cidade", "Estado", "", "Brasil", 100, null)]
    [InlineData("Rua", "Cidade", "Estado", "12345-678", "", 100, null)]
    public void InformAddress_Should_Throw_When_Arguments_Are_Invalid(string street, string city, string state, string zipCode, string country, int? number, string? complement)
    {
        var account = new Account();

        Assert.Throws<ArgumentException>(() =>
        {
            account.InformAddress(street, city, state, zipCode, country, number, complement);
        });
    }
}