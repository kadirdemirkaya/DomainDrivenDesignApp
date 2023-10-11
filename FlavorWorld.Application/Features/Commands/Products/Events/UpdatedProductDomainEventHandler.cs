using FlavorWorld.Domain.Aggregates.ProductAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FlavorWorld.Application.Features.Commands.Products.Events;

public sealed class UpdateProductDomainEventHandler : INotificationHandler<ProductUpdatedEvent>
{
    private readonly ILogger<UpdateProductDomainEventHandler> _logger;

    public UpdateProductDomainEventHandler(ILogger<UpdateProductDomainEventHandler> logger)
    {
        _logger = logger;
    }
    public async Task Handle(ProductUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Product Updated !  : {0}", notification.ProductName);
    }
}