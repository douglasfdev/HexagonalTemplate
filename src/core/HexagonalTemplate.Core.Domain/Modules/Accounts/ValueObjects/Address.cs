using HexagonalTemplate.Core.Utils.Guard;

namespace HexagonalTemplate.Core.Domain.Modules.Accounts.ValueObjects;

public record Address(
    string Street,
    string City,
    string State,
    string ZipCode,
    string Country,
    int? Number,
    string? Complement);