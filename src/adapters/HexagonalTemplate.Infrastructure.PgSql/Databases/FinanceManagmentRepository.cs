using System.Linq.Expressions;
using HexagonalTemplate.Core.Application.Abstractions.Ports.Repositories;
using HexagonalTemplate.Infrastructure.PgSql.Databases.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HexagonalTemplate.Infrastructure.PgSql.Databases;

public class FinanceManagmentRepository(FinanceManagementContext dbContext): IFinanceManagementRepository
{
    public async Task InsertAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
    {
        await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
    {
        dbContext.Set<TEntity>().Update(entity);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync<TEntity, TProperty>(Expression<Func<TEntity, bool>> expression, TProperty property, CancellationToken cancellationToken) where TEntity : class
    {
        var entity = await dbContext.Set<TEntity>().FirstAsync(expression, cancellationToken);
        dbContext.Attach(entity);
        dbContext.Entry(entity).Property(nameof(TProperty)).CurrentValue = property;

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken) where TEntity : class
    {
        var entity = await dbContext.Set<TEntity>().FirstAsync(expression, cancellationToken);
        dbContext.Set<TEntity>().Remove(entity);

        await dbContext.SaveChangesAsync(cancellationToken);

    }
}