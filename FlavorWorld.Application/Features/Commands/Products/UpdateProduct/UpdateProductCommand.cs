using FlavorWorld.Domain.Aggregates.ProductAggregate.Enums;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using MediatR;

namespace FlavorWorld.Application.Features.Commands.Products.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    decimal Price,
    DateTime CreatedDate,
    ProductStatus ProductStatus,
    ProductDetail ProductDetail
) : IRequest<bool>;