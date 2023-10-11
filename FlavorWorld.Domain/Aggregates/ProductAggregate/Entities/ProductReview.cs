using FlavorWorld.Abstractions.BaseTypes;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;

namespace FlavorWorld.Domain.Aggregates.ProductAggregate.Entities;

public sealed class ProductReview : Entity<ProductReviewId>
{
    public int Stars { get; set; }
    public DateTime CreatedDate { get; private set; }
    public string ProductName { get; private set; }

    public ProductId ProductId { get; private set; }


    public ProductReview()
    {

    }

    public ProductReview(ProductReviewId id, ProductId productId, int stars, DateTime createdDate, string productName) : base(id)
    {
        Stars = stars;
        CreatedDate = createdDate;
        ProductName = productName;
        ProductId = productId;
    }

    public static ProductReview Create(ProductId productId, int stars, DateTime createdDate, string productName)
    {
        var productReview = new ProductReview(ProductReviewId.CreateUnique(), productId, stars, createdDate, productName);
        return productReview;
    }
}