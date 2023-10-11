using FlavorWorld.Domain.BaseTypes;

namespace FlavorWorld.Domain.Aggregates.OrderAggregate.ValueObjects;

public sealed class OrderItemId : ValueObject
{
    public Guid Id { get; } = Guid.NewGuid();

    public OrderItemId(Guid id)
    {
        Id = id;
    }

    public static OrderItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static OrderItemId Create(Guid Id)
    {
        return new OrderItemId(Id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}