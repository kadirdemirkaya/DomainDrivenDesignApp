using FlavorWorld.Contracts.Models.Products;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Enums;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using MediatR;

namespace FlavorWorld.Application.Features.Commands.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    decimal Price,
    DateTime CreatedDate,
    ProductStatus ProductStatus,
    ProductDetail ProductDetail,
    List<ProductReviewCommand> ProductReviewsCommand
) : IRequest<bool>;

public record ProductReviewCommand(
    int Stars,
    DateTime CreatedDate
);