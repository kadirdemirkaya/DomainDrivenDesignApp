using FlavorWorld.Application.Common.Interfaces;

namespace FlavorWorld.Infrastructure.Persistence.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}