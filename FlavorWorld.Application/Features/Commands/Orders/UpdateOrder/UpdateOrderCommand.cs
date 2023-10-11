using MediatR;

namespace FlavorWorld.Application.Features.Commands.Orders.UpdateOrder;

public record UpdateOrderCommand(
   Guid orderId,
   string Description,
   DateTime CreatedDate,
   Guid UserId
) : IRequest<bool>;