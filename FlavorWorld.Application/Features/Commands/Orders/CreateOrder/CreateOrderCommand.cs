using MediatR;

namespace FlavorWorld.Application.Features.Commands.Orders.CreateOrder;

public record CreateOrderCommand(
   string Description,
   DateTime CreatedDate,
   Guid UserId,
   List<OrderItemCommand> OrderItemCommand
) : IRequest<bool>;

public record OrderItemCommand(
    string Description,
    DateTime CreatedDate,
    int Quantity,
    DateTime CreateDate,
    Guid OrderId,
    Guid ProductId
);