using System.Globalization;
using HexagonalTemplate.Core.Utils.Guard;

namespace HexagonalTemplate.Core.Domain.Modules.Budgets.ValueObjects;

public record Category(string Name, decimal Limit)
{
    private readonly List<Transaction> _transactions = new();

    public IEnumerable<Transaction> Transactions
        => _transactions.AsReadOnly();

    public void RegisterTransaction(DateTime createAt, string description, decimal value)
    {
        ArgumentGuard.AgainstNullOrWhiteSpace(description, nameof(description));
        ArgumentGuard.AgainstNullOrWhiteSpace(createAt.ToString(CultureInfo.InvariantCulture), nameof(createAt));
        ArgumentGuard.AgainstNullOrNegative(value, nameof(value));

        _transactions.Add(new(createAt, description, value));
    }
}