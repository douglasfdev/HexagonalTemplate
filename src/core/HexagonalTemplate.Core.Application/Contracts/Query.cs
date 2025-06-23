using HexagonalTemplate.Core.Application.Abstractions.Contracts;

namespace HexagonalTemplate.Core.Application.Contracts;

public static class Query
{
    public record GetBalanceQuery(Guid AccountId) : IQuery;

    public record ListCategoryQuery(Guid AccountId) : IQuery;

    public record ListExpenseByCategoryQuery(Guid AccountId, string Category) : IQuery;

    public record ListTransactionQuery(Guid AccountId, DateTime? CreateAt) : IQuery;
}