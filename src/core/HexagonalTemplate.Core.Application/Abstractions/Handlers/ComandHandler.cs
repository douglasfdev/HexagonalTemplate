using HexagonalTemplate.Core.Application.Abstractions.Contracts;
using HexagonalTemplate.Core.Application.Abstractions.Ports.Handlers;

namespace HexagonalTemplate.Core.Application.Abstractions.Handlers;

public abstract class CommandHandler<TCommand>: ICommandHandler<TCommand> where TCommand : ICommand
{
    public abstract Task Handle(TCommand command, CancellationToken cancellationToken);
}