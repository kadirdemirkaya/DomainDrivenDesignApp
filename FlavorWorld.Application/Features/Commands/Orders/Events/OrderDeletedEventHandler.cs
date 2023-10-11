using FlavorWorld.Domain.Aggregates.OrderAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FlavorWorld.Application.Features.Commands.Orders.Events;

public sealed class DeleteOrderDomainEventHandler : INotificationHandler<OrderDeletedEvent>
{
    private readonly ILogger<DeleteOrderDomainEventHandler> _logger;

    public DeleteOrderDomainEventHandler(ILogger<DeleteOrderDomainEventHandler> logger)
    {
        _logger = logger;
    }
    public async Task Handle(OrderDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Order Deleted !  : {0}", notification.id);
    }
}