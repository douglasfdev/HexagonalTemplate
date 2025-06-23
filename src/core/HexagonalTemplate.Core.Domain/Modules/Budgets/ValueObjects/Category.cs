namespace HexagonalTemplate.Core.Domain.Modules.Budgets.ValueObjects;

public record Category(string Name, decimal Limit)
{
    private readonly List<Transaction> _transactions = new();

    public IEnumerable<Transaction> Transactions
        => _transactions.AsReadOnly();

    public void RegisterTransaction(DateTime createAt, string description, decimal value)
    {
        _transactions.Add(new(createAt, description, value));
    }
}