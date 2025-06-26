using HexagonalTemplate.Core.Domain.Modules.Accounts.Entities;

namespace UnitTest;

public class ProfileTests
{
    [Theory]
    [InlineData("First Name", "Last Name", "email@email.com")]
    public void Create_Should_Set_Id_And_Properties(string firstName, string lastName, string email)
    {
        var profile = new Profile(firstName, lastName, email);

        Assert.Equal(firstName, profile.FirstName);
        Assert.Equal(lastName, profile.LastName);
        Assert.Equal(email, profile.Email);
    }
    
    [Theory]
    [InlineData("", "Last Name", "email@email.com")]
    [InlineData("First Name", "", "")]
    [InlineData("First Name", "Last Name", "")]
    public void Create_Should_Throw_When_Arguments_Are_Invalid(string firstName, string lastName, string email)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var profile = new Profile(firstName, lastName, email);
        });
    }
}