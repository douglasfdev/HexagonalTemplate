namespace HexagonalTemplate.Core.Application.Abstractions.Contracts;

public interface ICommand
{
    DateTimeOffset Timestamp { get; }
}