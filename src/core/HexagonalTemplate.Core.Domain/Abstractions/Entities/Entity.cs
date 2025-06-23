namespace HexagonalTemplate.Core.Domain.Abstractions.Entities;

public class Entity : IEntity
{
    public Guid Id { get; protected set; }
    
    public bool IsDeleted { get; protected set; }
}