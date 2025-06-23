using HexagonalTemplate.Core.Application.Dtos;

namespace HexagonalTemplate.Core.Application.Contracts;

public static class ViewModel
{
    public record BalanceViewModel(Guid AccountId, decimal Income, decimal Expense);

    public record CategoryViewModel(Guid AccountId, string CategoryName, decimal CategoryLimit);

    public record TransactionViewModel(TransactionViewModelDto TrasactionDto);
}