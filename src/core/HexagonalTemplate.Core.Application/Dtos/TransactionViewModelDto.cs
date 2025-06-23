namespace HexagonalTemplate.Core.Application.Dtos;

public class TransactionViewModelDto(Guid accountId, string category, DateTime createAt, string description, decimal value)
{
    public Guid AccountId { get; private set; } = accountId;

    public string Category { get; private set; } = category;
    
    public DateTime CreateAt { get; private set; } = createAt;
    
    public string Description { get; private set; } = description;
    
    public decimal Value { get; private set; } = value;
}