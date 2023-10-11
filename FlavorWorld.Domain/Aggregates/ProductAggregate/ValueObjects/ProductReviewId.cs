using FlavorWorld.Domain.BaseTypes;

namespace FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;

public sealed class ProductReviewId : ValueObject
{
    public Guid Id { get; }

    public ProductReviewId(Guid id)
    {
        Id = id;
    }

    public static ProductReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ProductReviewId Create(Guid Id)
    {
        return new ProductReviewId(Id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}