using FlavorWorld.Application.Common.Interfaces;
using FlavorWorld.Domain.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FlavorWorld.Application.Common.Services;

public class EmailSendService : BackgroundService
{
    private readonly ILogger<EmailSendService> _logger;
    private readonly IEmailQueueService _emailQueueService;

    public EmailSendService(ILogger<EmailSendService> logger, IEmailQueueService emailQueueService)
    {
        _logger = logger;
        _emailQueueService = emailQueueService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_emailQueueService.Queue.Any())
            {
                var msg = _emailQueueService.Queue.Dequeue();
                await SendEmail(msg);
            }
            await Task.Delay(1000, stoppingToken);
        }
    }

    public async Task SendEmail(EmailSetting msg)
    {
        await Task.Delay(1000);
        _logger.LogWarning("Email Send :--------===> " + msg.Message);
    }
}