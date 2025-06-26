using HexagonalTemplate.Core.Domain.Abstractions.Aggregates;

namespace UnitTest;

public class AggregateRootTests
{
    private class TestAggregateRoot : AggregateRoot
    {
        public void SetId(Guid id) => Id = id;
        public void SetIsDeleted(bool isDeleted) => IsDeleted = isDeleted;
    }

    [Theory]
    [InlineData("b3b6a6e2-1c2d-4e3a-9b2a-1a2b3c4d5e6f", false)]
    [InlineData("11111111-1111-1111-1111-111111111111", true)]
    public void AggregateRoot_Properties_Are_Set_Correctly(string guidString, bool isDeleted)
    {
        var id = Guid.Parse(guidString);
        var aggregate = new TestAggregateRoot();

        aggregate.SetId(id);
        aggregate.SetIsDeleted(isDeleted);
        
        Assert.Equal(id, aggregate.Id);
        Assert.Equal(isDeleted, aggregate.IsDeleted);
        Assert.IsAssignableFrom<AggregateRoot>(aggregate);
    }
    
    [Theory]
    [InlineData("valor-invalido", false)]
    public void AggregateRoot_Throws_FormatException_When_Guid_Is_Invalid(string guidString, bool isDeleted)
    {
        Assert.Throws<FormatException>(() =>
        {
            var id = Guid.Parse(guidString);
            var aggregate = new TestAggregateRoot();
            aggregate.SetId(id);
            aggregate.SetIsDeleted(isDeleted);
        });
    }
}