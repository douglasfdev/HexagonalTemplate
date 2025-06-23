using HexagonalTemplate.Core.Application.Abstractions.Contracts;
using HexagonalTemplate.Core.Application.Abstractions.Ports.Handlers;

namespace HexagonalTemplate.Core.Application.Abstractions.Handlers;

public abstract class QueryHandler<TQuery, TResponse> : IQueryHandler<TQuery, TResponse> where TQuery : IQuery
{
    public abstract Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}