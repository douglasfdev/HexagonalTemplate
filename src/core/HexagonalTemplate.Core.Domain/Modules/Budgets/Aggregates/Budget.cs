using System.Globalization;
using HexagonalTemplate.Core.Domain.Abstractions.Aggregates;
using HexagonalTemplate.Core.Domain.Modules.Budgets.ValueObjects;
using HexagonalTemplate.Core.Utils.Guard;

namespace HexagonalTemplate.Core.Domain.Modules.Budgets.Aggregates;

public class Budget: AggregateRoot
 {
    private readonly List<Category> _categories = new();
    
    public Guid OwnerId { get; private set; }
    
    public DateOnly ReferencePeriod { get; private set; }
    
    public decimal TotalValue { get; private set; }

    public IEnumerable<Category> Categories => _categories.AsReadOnly();
    
    public void Register(Guid ownerId, DateOnly referencePeriod, decimal totalValue)
    {
        ArgumentGuard.AgainstNullOrWhiteSpace(ownerId.ToString(), nameof(ownerId));
        ArgumentGuard.AgainstNullOrWhiteSpace(referencePeriod.ToString(), nameof(referencePeriod));
        ArgumentGuard.AgainstNullOrNegative(totalValue, nameof(totalValue));
        
        OwnerId = ownerId;
        ReferencePeriod = referencePeriod;
        TotalValue = totalValue;
    }
    
    public void AddCategory(string name, decimal limit)
    {
        ArgumentGuard.AgainstNullOrWhiteSpace(name, nameof(name));
        ArgumentGuard.AgainstNullOrNegative(limit, nameof(limit));
        
        _categories.Add(new (name, limit));
    }
    
    public void UpdateTotalValue(decimal totalValue)
    {
        ArgumentGuard.AgainstNullOrNegative(totalValue, nameof(totalValue));
        
        TotalValue = totalValue;
    }

    public void RegisterTransaction(string category, DateTime createAt, string description, decimal value)
    {
        ArgumentGuard.AgainstNullOrWhiteSpace(category, nameof(category));
        ArgumentGuard.AgainstNullOrWhiteSpace(createAt.ToString(CultureInfo.InvariantCulture), nameof(category));
        ArgumentGuard.AgainstNullOrWhiteSpace(description, nameof(description));
        ArgumentGuard.AgainstNullOrNegative(value, nameof(value));
        
        _categories
            .Single(c => c.Name.Equals(category, StringComparison.OrdinalIgnoreCase))
            .RegisterTransaction(createAt, description, value);
    }
}