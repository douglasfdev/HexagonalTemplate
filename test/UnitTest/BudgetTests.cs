using HexagonalTemplate.Core.Domain.Abstractions.Aggregates;
using HexagonalTemplate.Core.Domain.Modules.Budgets.Aggregates;

namespace UnitTest;

public class BudgetTests
{
    [Theory]
    [InlineData("b3b6a6e2-1c2d-4e3a-9b2a-1a2b3c4d5e6f", "2025-06-27", 1000.00)]
    public void Register_Properties_Are_Set_Correctly(Guid ownerId, string referencePeriodString, decimal totalValue)
    {
        DateOnly referencePeriod = DateOnly.Parse(referencePeriodString);

        var budget = new Budget();
        budget.Register(ownerId, referencePeriod, totalValue);

        Assert.Equal(ownerId, budget.OwnerId);
        Assert.Equal(referencePeriod, budget.ReferencePeriod);
        Assert.Equal(totalValue, budget.TotalValue);
    }
    
    [Theory]
    [InlineData(500.00)]
    public void UpdateTotalValue_Should_Update_TotalValue(decimal totalValue)
    {
        var budget = new Budget();
        budget.UpdateTotalValue(totalValue);

        Assert.Equal(totalValue, budget.TotalValue);
    }
    
    [Theory]
    [InlineData("Food", "2025-06-27",  "Grocery shopping", 300.00)]
    public void RegisterTransaction_Should_Register_Transaction(string category, string createAt, string description, decimal value)
    {
        var budget = new Budget();
        budget.AddCategory(category, 500.00m);
        
        var createdAt = DateTime.Parse(createAt);

        budget.RegisterTransaction(category, createdAt, description, value);

        var registeredCategory = budget.Categories.Single(c => c.Name == category);
        var transaction = registeredCategory.Transactions.Single(t => t.Description == description && t.Value == value);

        Assert.NotNull(transaction);
        Assert.Equal(createdAt, transaction.CreateAt);
    }
    
    [Theory]
    [InlineData("valor-invalido", "2025-06-27", -300.00)]
    public void Register_Should_Throw_When_Arguments_Are_Invalid(string ownerId, string createAt, decimal value)
    {
        Budget budget = new();
        var id = Guid.Empty;

        Assert.Throws<FormatException>(() =>
        {
            Guid.Parse(ownerId);
        });

        Assert.Throws<ArgumentException>(() =>
        {
            budget.Register(id, DateOnly.Parse(createAt), value);
        });
    }
    
    [Theory]
    [InlineData("valor-invalido", "2025-06-27", "Grocery shopping", -300.00)]
    public void RegisterTransaction_Should_Throw_When_Arguments_Are_Invalid(string category, string createAt, string description, decimal value)
    {
        Budget budget = new();
        budget.AddCategory("Food", 500.00m);
        
        Assert.Throws<ArgumentException>(() =>
        {
            budget.RegisterTransaction(category, DateTime.Parse(createAt), description, value);
        });
    }
    
    [Theory]
    [InlineData(-1000.00)]
    public void UpdateTotalValue_Should_Throw_When_Value_Is_Invalid( decimal totalValue)
    {
        Budget budget = new();

        Assert.Throws<ArgumentException>(() =>
        {
            budget.UpdateTotalValue(totalValue);
        });
    }
}