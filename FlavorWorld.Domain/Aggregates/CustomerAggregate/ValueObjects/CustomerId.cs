using FlavorWorld.Domain.BaseTypes;

namespace FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;

public sealed class CustomerId : ValueObject
{
    public Guid Id { get; }

    public CustomerId(Guid id)
    {
        Id = id;
    }

    public static CustomerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static CustomerId Create(Guid Id)
    {
        return new CustomerId(Id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}