using HexagonalTemplate.Core.Domain.Modules.Budgets.ValueObjects;

namespace UnitTest;

public class CategoryTests
{
    private DateTime _dateTime;

    [Theory]
    [InlineData("Category Name", 50.0000)]
    public void Should_Create_Category(string name, decimal limit)
    {
        var category = new Category(name, limit);
        
        Assert.Equal(name, category.Name);
        Assert.Equal(limit, category.Limit);
    }
    
    [Theory]
    [InlineData("Category Name", 50.0000, "2025-06-27", "Transaction Description", 20.00)]
    public void Should_Register_Transaction(string name, decimal limit, string createAt, string description, decimal value)
    {
        var category = new Category(name, limit);
        var createdAt = DateTime.Parse(createAt);
        
        category.RegisterTransaction(createdAt, description, value);
        
        var transaction = category.Transactions.Single(t => t.Description == description && t.Value == value);
        
        Assert.NotNull(transaction);
        Assert.Equal(createdAt, transaction.CreateAt);
    }
    
    [Theory]
    [InlineData("Category Name", 50.0000, "2025-06-27", "Transaction Description", -20.00)]
    [InlineData("Category Name", 50.0000, "2025-06-27", "", 20.00)]
    [InlineData("Category Name", 50.0000, "2025-06-27", "Transaction Description", 0.00)]
    public void Should_Throw_ArgumentException_When_Registering_Invalid_Transaction(string name, decimal limit, string createAt, string description, decimal value)
    {
        var category = new Category(name, limit);
        var createdAt = DateTime.Parse(createAt);

        Assert.Throws<ArgumentException>(() =>
        {
            category.RegisterTransaction(createdAt, description, value);
        });
    }

    [Theory]
    [InlineData("Category Name", 50.0000, "invalid-date", "Transaction Description", 20.00)]
    public void Should_Throw_FormatException_When_Invalid_Date_Format_Is_Provided(string name, decimal limit, string createAt, string description, decimal value)
    {
        var category = new Category(name, limit);

        Assert.Throws<FormatException>(() =>
        {
            var parsedDate = DateTime.Parse(createAt);
            category.RegisterTransaction(parsedDate, description, value); // Esta linha não será alcançada
        });
    }

}