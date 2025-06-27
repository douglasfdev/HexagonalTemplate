using HexagonalTemplate.Core.Application.Abstractions.Handlers;
using HexagonalTemplate.Core.Application.Abstractions.Ports.Repositories;
using HexagonalTemplate.Core.Application.Contracts;

namespace HexagonalTemplate.Core.Application.Modules.Budgets.QueryHandlers;

public class ListCategoryHandler(IFinanceManagementReadRepository financeManagementReadRepository) : QueryHandler<Query.ListCategoryQuery, List<ViewModel.CategoryViewModel>>
{
    public override async Task<List<ViewModel.CategoryViewModel>> Handle(Query.ListCategoryQuery query, CancellationToken cancellationToken)
    {
        var categories = await financeManagementReadRepository.ListAsync<ViewModel
            .CategoryViewModel>(prop => prop.BudgetId == query.BudgetId, cancellationToken);
        return categories;
    }
}