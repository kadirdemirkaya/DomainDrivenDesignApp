using FlavorWorld.Domain.Aggregates.UserAggregate;

namespace FlavorWorld.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}