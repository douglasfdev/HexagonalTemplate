using HexagonalTemplate.Core.Application.Abstractions.Handlers;
using HexagonalTemplate.Core.Application.Abstractions.Ports.Repositories;
using HexagonalTemplate.Core.Application.Contracts;
using HexagonalTemplate.Core.Domain.Modules.Budgets.Aggregates;

namespace HexagonalTemplate.Core.Application.Modules.Budgets.CommandHandlers;

public class AddCategoryHandler(IFinanceManagementRepository financeManagementRepository): CommandHandler<Command.AddCategoryCommand>
{
    public override async Task Handle(Command.AddCategoryCommand command, CancellationToken cancellationToken)
    {
        Budget? budget =
            await financeManagementRepository.GetAsync<Budget>(prop => prop.Id == command.BudgetId, cancellationToken);
        
        if (budget is null)
            throw new Exception("Budget not found");

        await financeManagementRepository.UpdateAsync(budget, cancellationToken);
    }
}