using HexagonalTemplate.Core.Domain.Abstractions.Entities;

namespace HexagonalTemplate.Core.Domain.Modules.Accounts.Entities;

public class Profile(string firstName, string lastName, string email): Entity
{
    public string FirstName { get; private set; } = firstName;
    
    public string LastName { get; private set; } = lastName;
    
    public string Email { get; private set; } = email;
}