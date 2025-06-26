using HexagonalTemplate.Core.Domain.Abstractions.Entities;

namespace UnitTest;

public class BaseEntityTests
{
    private class TestEntity : Entity
    {
        public TestEntity(Guid id, bool isDeleted)
        {
            Id = id;
            IsDeleted = isDeleted;
        }
    }

    
    [Theory]
    [InlineData("b3b6a6e2-1c2d-4e3a-9b2a-1a2b3c4d5e6f", false)]
    [InlineData("11111111-1111-1111-1111-111111111111", true)]
    public void Entity_Properties_Are_Set_Correctly(string guidString, bool isDeleted)
    {
        var id = Guid.Parse(guidString);

        var entity = new TestEntity(id, isDeleted);

        Assert.Equal(id, entity.Id);
        Assert.Equal(isDeleted, entity.IsDeleted);
    }
    
    [Theory]
    [InlineData("valor-invalido", false)]
    public void Entity_Throws_FormatException_When_Guid_Is_Invalid(string guidString, bool isDeleted)
    {
        Assert.Throws<FormatException>(() =>
        {
            var id = Guid.Parse(guidString);
            var entity = new TestEntity(id, isDeleted);
        });
    }
}