using FlavorWorld.Application.Common.Interfaces;
using FlavorWorld.Domain.Models;

namespace FlavorWorld.Infrastructure.Persistence.Services;

public class EmailQueueService : IEmailQueueService
{
    public Queue<EmailSetting> Queue { get; set; }

    public EmailQueueService(Queue<EmailSetting> queue)
    {
        Queue = queue;
    }
}