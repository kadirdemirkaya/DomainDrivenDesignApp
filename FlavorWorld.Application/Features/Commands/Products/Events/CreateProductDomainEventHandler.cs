using FlavorWorld.Domain.Aggregates.ProductAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FlavorWorld.Application.Features.Commands.Products.Events;

public sealed class CreateProductDomainEventHandler : INotificationHandler<ProductCreatedEvent>
{
    private readonly ILogger<CreateProductDomainEventHandler> _logger;

    public CreateProductDomainEventHandler(ILogger<CreateProductDomainEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Product Created !  : {0}", notification.ProductName);
    }
}