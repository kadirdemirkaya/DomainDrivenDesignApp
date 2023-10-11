using FlavorWorld.Domain.Aggregates.ProductAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FlavorWorld.Application.Features.Commands.Products.Events;

public sealed class DeleteProductDomainEventHandler : INotificationHandler<ProductDeletedEvent>
{
    private readonly ILogger<DeleteProductDomainEventHandler> _logger;

    public DeleteProductDomainEventHandler(ILogger<DeleteProductDomainEventHandler> logger)
    {
        _logger = logger;
    }
    public async Task Handle(ProductDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Product Deleted !  : {0}", notification.id);
    }
}