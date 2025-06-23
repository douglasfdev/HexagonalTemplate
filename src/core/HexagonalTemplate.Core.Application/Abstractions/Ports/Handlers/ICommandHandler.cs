using HexagonalTemplate.Core.Application.Abstractions.Contracts;

namespace HexagonalTemplate.Core.Application.Abstractions.Ports.Handlers;

public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    Task Handle(TCommand command, CancellationToken cancellationToken);
}