using FlavorWorld.Contracts.Models;
using MediatR;

namespace FlavorWorld.Application.Features.Queries.Authentication.Login;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<AuthenticationResult>;