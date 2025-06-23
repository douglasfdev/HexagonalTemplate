using HexagonalTemplate.Core.Application.Abstractions.Handlers;
using HexagonalTemplate.Core.Application.Abstractions.Ports.Repositories;
using HexagonalTemplate.Core.Application.Contracts;
using HexagonalTemplate.Core.Domain.Modules.Accounts.Aggregates;

namespace HexagonalTemplate.Core.Application.Modules.Accounts.CommandHandlers;

public class CreateAccountHandler(IFinanceManagementRepository financeManagementRepository) : CommandHandler<Command.CreateAccountCommand>
{
    public override async Task Handle(Command.CreateAccountCommand command, CancellationToken cancellationToken)
    {
        Account account = new();
        
        account.Create(command.FirstName, command.LastName, command.Email);

        await financeManagementRepository.InsertAsync(account, cancellationToken);
    }
}