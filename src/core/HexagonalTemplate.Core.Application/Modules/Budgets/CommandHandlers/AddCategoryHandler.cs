using HexagonalTemplate.Core.Application.Abstractions.Handlers;
using HexagonalTemplate.Core.Application.Abstractions.Ports.Repositories;
using HexagonalTemplate.Core.Application.Contracts;
using HexagonalTemplate.Core.Domain.Modules.Budgets.Aggregates;

namespace HexagonalTemplate.Core.Application.Modules.Budgets.CommandHandlers;

public class AddCategoryHandler(IFinanceManagementRepository financeManagementRepository, IFinanceManagementReadRepository financeManagementReadRepository): CommandHandler<Command.AddCategoryCommand>
{
    public override async Task Handle(Command.AddCategoryCommand command, CancellationToken cancellationToken)
    {
        Budget? budget =
            await financeManagementReadRepository.GetAsync<Budget>(prop => prop.Id == command.BudgetId, cancellationToken);
        
        if (budget is null)
            throw new Exception("Budget not found");
        
        budget.AddCategory(command.Name, command.Limit);

        await financeManagementRepository.UpdateAsync(budget, cancellationToken);
    }
}