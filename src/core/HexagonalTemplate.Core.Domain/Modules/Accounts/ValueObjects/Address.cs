namespace HexagonalTemplate.Core.Domain.Modules.Accounts.ValueObjects;

public record Address(string Street, string City, string State, string ZepCode, string Country, int? Number, string? Complement);