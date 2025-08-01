using System.Linq.Expressions;

namespace HexagonalTemplate.Core.Application.Abstractions.Ports.Repositories;

public interface IFinanceManagementRepository
{
    Task InsertAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
        where TEntity : class;

    Task UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
        where TEntity : class;

    Task UpdateAsync<TEntity, TProperty>(Expression<Func<TEntity, bool>> expression, TProperty property, CancellationToken cancellationToken)
        where TEntity : class;

    Task DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
        where TEntity : class;

}