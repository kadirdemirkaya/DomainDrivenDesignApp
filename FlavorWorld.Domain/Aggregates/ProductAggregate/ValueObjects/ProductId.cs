using FlavorWorld.Domain.BaseTypes;

namespace FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;

public sealed class ProductId : ValueObject
{
    public Guid Id { get; }


    public ProductId(Guid id)
    {
        Id = id;
    }

    public static ProductId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ProductId Create(Guid Id)
    {
        return new ProductId(Id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}