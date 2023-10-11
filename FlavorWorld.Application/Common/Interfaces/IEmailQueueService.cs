using FlavorWorld.Domain.Models;

namespace FlavorWorld.Application.Common.Interfaces;

public interface IEmailQueueService
{
    Queue<EmailSetting> Queue { get; set; }
}