using MediatR;

namespace FlavorWorld.Application.Features.Commands.Orders.DeleteOrder;

public record DeleteOrderCommand(
    Guid id
) : IRequest<bool>;
