using FlavorWorld.Domain.Aggregates.OrderAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FlavorWorld.Application.Features.Commands.Orders.Events;

public sealed class CreateOrderDomainEventHandler : INotificationHandler<OrderCreatedEvent>
{
    private readonly ILogger<CreateOrderDomainEventHandler> _logger;

    public CreateOrderDomainEventHandler(ILogger<CreateOrderDomainEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Order Created !  : {0}", notification.orderId);
    }
}