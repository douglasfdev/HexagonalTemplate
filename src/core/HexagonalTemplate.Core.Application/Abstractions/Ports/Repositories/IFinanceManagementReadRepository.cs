using System.Linq.Expressions;

namespace HexagonalTemplate.Core.Application.Abstractions.Ports.Repositories;

public interface IFinanceManagementReadRepository
{
    Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
        where TEntity : class;

    Task<List<TEntity>> ListAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
        where TEntity : class;
}