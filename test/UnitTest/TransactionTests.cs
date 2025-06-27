using HexagonalTemplate.Core.Domain.Modules.Budgets.ValueObjects;

namespace UnitTest;

public class TransactionTests
{
    [Theory]
    [InlineData("2023-10-01T12:00:00", "Test Transaction", 100.50)]
    public void Should_Create_Transaction_With_Valid_Values(string createAtString, string description, decimal value)
    {
        var createAt = DateTime.Parse(createAtString);
        
        var transaction = new HexagonalTemplate.Core.Domain.Modules.Budgets.ValueObjects.Transaction(createAt, description, value);

        Assert.Equal(createAt, transaction.CreateAt);
        Assert.Equal(description, transaction.Description);
        Assert.Equal(value, transaction.Value);
    }
    
    [Theory]
    [InlineData("data-invalida", "Descrição qualquer", 100.50)]
    [InlineData("2023-13-01T12:00:00", "Outra descrição", 50.00)]
    [InlineData("2023-02-30T12:00:00", "Mais uma", 10.00)]
    [InlineData("2023-10-01T25:00:00", "Teste", 1.00)]
    [InlineData("", "Vazio", 0.00)]
    public void Should_Throw_ArgumentException_When_Invalid_Dates_Are_Provided(string createAtString, string description, decimal value)
    {
        
        Assert.Throws<FormatException>(() =>
        {
            var createAt = DateTime.Parse(createAtString);

            new Transaction(createAt, description, value);
        });
    }
}