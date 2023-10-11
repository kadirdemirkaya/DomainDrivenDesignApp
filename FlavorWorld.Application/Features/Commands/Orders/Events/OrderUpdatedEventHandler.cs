using FlavorWorld.Domain.Aggregates.OrderAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FlavorWorld.Application.Features.Commands.Orders.Events;

public sealed class UpdateOrderDomainEventHandler : INotificationHandler<OrderUpdatedEvent>
{
    private readonly ILogger<UpdateOrderDomainEventHandler> _logger;

    public UpdateOrderDomainEventHandler(ILogger<UpdateOrderDomainEventHandler> logger)
    {
        _logger = logger;
    }
    public async Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Order Updated !  : {0}", notification.orderId);
    }
}