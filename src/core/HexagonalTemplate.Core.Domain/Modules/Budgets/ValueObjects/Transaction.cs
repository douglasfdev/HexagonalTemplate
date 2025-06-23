namespace HexagonalTemplate.Core.Domain.Modules.Budgets.ValueObjects;

public record Transaction(DateTime CreateAt, string Description, decimal Value);