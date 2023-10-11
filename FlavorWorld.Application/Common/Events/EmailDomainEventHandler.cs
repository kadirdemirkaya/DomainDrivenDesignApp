using FlavorWorld.Application.Common.Interfaces;
using FlavorWorld.Domain.Common.Events;
using MediatR;

namespace FlavorWorld.Application.Features.Commands.Products.Events;

public sealed class EmailDomainEventHandler : INotificationHandler<EmailDomainEvent>
{
    private readonly IEmailQueueService _emailQueueService;

    public EmailDomainEventHandler(IEmailQueueService emailQueueService)
    {
        _emailQueueService = emailQueueService;
    }

    public async Task Handle(EmailDomainEvent notification, CancellationToken cancellationToken)
    {
        _emailQueueService.Queue.Enqueue(notification.EmailSetting);
    }
}