using AutoMapper;
using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Application.Common.Interfaces;
using FlavorWorld.Contracts.Models;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.Aggregates.UserAggregate;
using MediatR;
using Microsoft.AspNetCore.Authentication;

namespace FlavorWorld.Application.Features.Queries.Authentication.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationResult>
{
    private readonly IMapper _mapper;
    private readonly IUserReadRepository<User, UserId> _userReadRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginCommandHandler(IMapper mapper, IUserReadRepository<User, UserId> userReadRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _mapper = mapper;
        _userReadRepository = userReadRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.GetAsync(u => u.Email == request.Email);
        if (user is not null)
        {
            if (user.Password == request.Password)
            {
                var token = _jwtTokenGenerator.GenerateToken(user);
                return new() { Token = token, isSuccess = true };
            }
            else
                return new() { Token = string.Empty, isSuccess = false };
        }
        else
            return new() { Token = string.Empty, isSuccess = false };
    }
}