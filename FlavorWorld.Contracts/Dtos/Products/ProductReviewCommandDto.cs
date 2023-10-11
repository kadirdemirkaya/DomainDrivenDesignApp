using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;

namespace FlavorWorld.Contracts.Models.Products;

public class ProductReviewCommandDto
{
    public int Stars { get; set; }
    public DateTime CreatedDate { get; set; }
}