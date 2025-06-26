using HexagonalTemplate.Core.Domain.Abstractions.Aggregates;
using HexagonalTemplate.Core.Domain.Modules.Accounts.Entities;
using HexagonalTemplate.Core.Domain.Modules.Accounts.ValueObjects;
using HexagonalTemplate.Core.Utils.Guard;

namespace HexagonalTemplate.Core.Domain.Modules.Accounts.Aggregates;

public class Account: AggregateRoot
{
    public Profile Profile { get; private set; }
    
    public Address? Address { get; private set; }
    
    public void Create(string firstName, string lastName, string email)
    {        
        ArgumentGuard.AgainstNullOrWhiteSpace(firstName, nameof(firstName));
        ArgumentGuard.AgainstNullOrWhiteSpace(lastName, nameof(lastName));
        ArgumentGuard.AgainstNullOrWhiteSpace(email, nameof(email));

        Id = Guid.NewGuid();
        Profile = new Profile(firstName, lastName, email);
    }
    
    public void InformAddress(string street, string city, string state, string zipCode, string country, int? number, string? complement)
    {
        ArgumentGuard.AgainstNullOrWhiteSpace(street, nameof(street));
        ArgumentGuard.AgainstNullOrWhiteSpace(city, nameof(city));
        ArgumentGuard.AgainstNullOrWhiteSpace(state, nameof(state));
        ArgumentGuard.AgainstNullOrWhiteSpace(zipCode, nameof(zipCode));
        ArgumentGuard.AgainstNullOrWhiteSpace(country, nameof(country));
        ArgumentGuard.AgainstNullOrNegative(number, nameof(number));
        ArgumentGuard.AgainstNullOrWhiteSpace(complement, nameof(complement));

        Address = new Address(street, city, state, zipCode, country, number, complement);
    }
}