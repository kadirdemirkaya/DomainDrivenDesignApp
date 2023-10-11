using FlavorWorld.Domain.Aggregates.ProductAggregate;
using MediatR;

namespace FlavorWorld.Application.Features.Query.Products.GetProduct;

public record GetProductQuery(
    Guid id
) : IRequest<Product>;
