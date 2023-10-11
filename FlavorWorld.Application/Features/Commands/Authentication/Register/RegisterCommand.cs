using FlavorWorld.Contracts.Models;
using FlavorWorld.Domain.Aggregates.UserAggregate.Enums;
using MediatR;

namespace FlavorWorld.Application.Features.Commands.Authentication.Register;

public record RegisterCommand(
    string UserName,
    string Email,
    string Password,
    DateTime CreatedDate,
    UserStatus UserStatus,
    Guid CustomerId,
    List<RoleCommand> Roles
) : IRequest<AuthenticationResult>;

public record RoleCommand(
    string RoleName
);