using HexagonalTemplate.Core.Domain.Abstractions.Aggregates;
using HexagonalTemplate.Core.Domain.Modules.Accounts.Entities;
using HexagonalTemplate.Core.Domain.Modules.Accounts.ValueObjects;

namespace HexagonalTemplate.Core.Domain.Modules.Accounts.Aggregates;

public class Account: AggregateRoot
{
    public Profile Profile { get; private set; }
    
    public Address? Address { get; private set; }
    
    public void Create(string firstName, string lastName, string email)
    {        
        Id = Guid.NewGuid();
        Profile = new Profile(firstName, lastName, email);
    }
    
    public void InformAddress(string street, string city, string state, string zepCode, string country, int? number, string? complement)
    {
        Address = new Address(street, city, state, zepCode, country, number, complement);
    }
}