using HexagonalTemplate.Core.Application.Abstractions.Ports.Handlers;
using HexagonalTemplate.Core.Application.Contracts;
using HexagonalTemplate.Core.Application.Modules.Accounts.CommandHandlers;
using HexagonalTemplate.Core.Application.Modules.Budgets.CommandHandlers;
using HexagonalTemplate.Core.Application.Modules.Budgets.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace HexagonalTemplate.Core.Application;

public static class ApplicationLayerDependency
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddTransient<ICommandHandler<Command.CreateAccountCommand>, CreateAccountHandler>();
        services.AddTransient<ICommandHandler<Command.RegisterBudgetCommand>, RegisterBudgetHandler>();
        services.AddTransient<ICommandHandler<Command.AddCategoryCommand>, AddCategoryHandler>();

        services.AddTransient<IQueryHandler<Query.ListCategoryQuery, List<ViewModel.
            CategoryViewModel>>, ListCategoryHandler>();

    }
}