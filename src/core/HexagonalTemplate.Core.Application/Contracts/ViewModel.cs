namespace HexagonalTemplate.Core.Application.Contracts;

public static class ViewModel
{
    public record BalanceViewModel(Guid AccountId, decimal Income, decimal Expense);

    public record CategoryViewModel(Guid BudgetId, string CategoryName, decimal CategoryLimit);

    public record TransactionViewModel(
        Guid AccountId,
        string Category,
        DateTime CreateAt,
        string Description,
        decimal Value
    );
}