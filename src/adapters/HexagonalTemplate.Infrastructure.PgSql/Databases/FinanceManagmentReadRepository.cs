using System.Linq.Expressions;
using HexagonalTemplate.Core.Application.Abstractions.Ports.Repositories;
using HexagonalTemplate.Infrastructure.PgSql.Databases.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HexagonalTemplate.Infrastructure.PgSql.Databases;

public class FinanceManagmentReadRepository(FinanceManagementReadContext dbContext) :  IFinanceManagementReadRepository
{
    public async Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken) where TEntity : class
        => await dbContext.Set<TEntity>().AsSplitQuery().FirstOrDefaultAsync(expression, cancellationToken);

    public async Task<List<TEntity>> ListAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken) where TEntity : class
        => await dbContext.Set<TEntity>().Where(expression).ToListAsync(cancellationToken);
}