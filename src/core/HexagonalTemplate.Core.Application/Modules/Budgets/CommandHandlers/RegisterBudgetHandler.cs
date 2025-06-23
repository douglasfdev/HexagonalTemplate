using HexagonalTemplate.Core.Application.Abstractions.Handlers;
using HexagonalTemplate.Core.Application.Abstractions.Ports.Repositories;
using HexagonalTemplate.Core.Application.Contracts;
using HexagonalTemplate.Core.Domain.Modules.Budgets.Aggregates;

namespace HexagonalTemplate.Core.Application.Modules.Budgets.CommandHandlers;

public class RegisterBudgetHandler(IFinanceManagementRepository financeManagementRepository): CommandHandler<Command.RegisterBudgetCommand>
{
    public override async Task Handle(Command.RegisterBudgetCommand command, CancellationToken cancellationToken)
    {
        Budget budget = new();
        budget.Register(command.AccountId, command.ReferencePeriod, command.TotalValue);

        await financeManagementRepository.InsertAsync(budget, cancellationToken);
    }
}