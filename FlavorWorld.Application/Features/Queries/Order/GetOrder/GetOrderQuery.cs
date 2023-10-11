using FlavorWorld.Domain.Aggregates.OrderAggregate;
using MediatR;

namespace FlavorWorld.Application.Features.Query.Orders.GetProduct;

public record GetOrderQuery(
    Guid id
) : IRequest<Order>;
