using FlavorWorld.Application.Common.Interfaces;
using FlavorWorld.Domain.Aggregates.UserAggregate.Events;
using FlavorWorld.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FlavorWorld.Application.Features.Commands.Orders.Events;

public sealed class RegisterDomainEventHandler : INotificationHandler<RegisterDomainEvent>
{
    private readonly ILogger<RegisterDomainEventHandler> _logger;

    public RegisterDomainEventHandler(ILogger<RegisterDomainEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(RegisterDomainEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Register Name !  : {0}", notification.Name);
    }
}