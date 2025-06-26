using HexagonalTemplate.Core.Domain.Abstractions.Entities;
using HexagonalTemplate.Core.Domain.Modules.Accounts.Aggregates;
using HexagonalTemplate.Core.Utils.Guard;

namespace HexagonalTemplate.Core.Domain.Modules.Accounts.Entities;

public class Profile : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    protected Profile() { }

    public Profile(string firstName, string lastName, string email)
    {
        ArgumentGuard.AgainstNullOrWhiteSpace(firstName, nameof(firstName));
        ArgumentGuard.AgainstNullOrWhiteSpace(lastName, nameof(lastName));
        ArgumentGuard.AgainstNullOrWhiteSpace(email, nameof(email));
        
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public Guid AccountId { get; private set; }
    public Account Account { get; private set; } = null!;
}
