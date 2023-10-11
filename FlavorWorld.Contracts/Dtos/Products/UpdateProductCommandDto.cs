using FlavorWorld.Domain.Aggregates.ProductAggregate.Enums;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;

namespace FlavorWorld.Contracts.Models.Products;

public class UpdateProductCommandDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set; }
    public ProductStatus ProductStatus { get; set; }
    public ProductDetail ProductDetail { get; set; }
}