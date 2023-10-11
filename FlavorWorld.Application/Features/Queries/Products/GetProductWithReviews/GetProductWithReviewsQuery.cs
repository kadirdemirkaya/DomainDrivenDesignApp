using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Entities;
using MediatR;

namespace FlavorWorld.Application.Features.Query.Products.CreateProduct;

public record GetProductWithReviewsQuery(
    Guid id
) : IRequest<List<ProductReview>>;
