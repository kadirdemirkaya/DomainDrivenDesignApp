using AutoMapper;
using FlavorWorld.Abstractions.Repository;
using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Application.Features.Commands.Authentication.Register;
using FlavorWorld.Contracts.Models;
using FlavorWorld.Domain.Aggregates.CustomerAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.Aggregates.UserAggregate;
using FlavorWorld.Domain.Aggregates.UserAggregate.Events;
using FlavorWorld.Domain.Common.Events;
using FlavorWorld.Domain.Services;
using MediatR;

namespace FlavorWorld.Application.Features.Commands.Orders.CreateOrder;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IMapper _mapper;
    private readonly IUserReadRepository<User, UserId> _userReadRepository;
    private readonly IUserWriteRepository<User, UserId> _userWriteRepository;
    private readonly ICustomerReadRepository<Customer, CustomerId> _customerReadRepository;
    private readonly IUserRoleService _userRoleService;
    private readonly IRoleReadRepository _roleReadRepository;
    private readonly IRoleWriteRepository _roleWriteRepository;

    public RegisterCommandHandler(IMapper mapper, IUserReadRepository<User, UserId> userReadRepository, IUserWriteRepository<User, UserId> userWriteRepository, ICustomerReadRepository<Customer, CustomerId> customerReadRepository, IUserRoleService userRoleService, IRoleReadRepository roleReadRepository, IRoleWriteRepository roleWriteRepository)
    {
        _mapper = mapper;
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
        _customerReadRepository = customerReadRepository;
        _userRoleService = userRoleService;
        _roleReadRepository = roleReadRepository;
        _roleWriteRepository = roleWriteRepository;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.GetAsync(r => r.Email == request.Email);
        if (user is null)
        {
            var newUser = User.Create(request.UserName, request.Email, request.Password, request.CreatedDate, request.UserStatus);
            await _userWriteRepository.CreateAsync(newUser);
            List<Guid> RoleIds = new();
            foreach (var role in request.Roles)
            {
                var localRole = await _roleReadRepository.GetAsync(r => r.Name == role.RoleName);
                RoleIds.Add(localRole.Id);
            }
            newUser.AddUserDomainEvent(new EmailDomainEvent(new() { Message = $"{request.Email} created succesfully", ToEmail = request.Email }));
            newUser.AddUserDomainEvent(new RegisterDomainEvent(newUser.Username));
            await _userRoleService.CreateUserRole(newUser.Id, RoleIds);
            await _userWriteRepository.SaveChangesAsync();
            return new() { Token = string.Empty, isSuccess = true };
        }
        else
        {
            return new() { Token = string.Empty, isSuccess = false };
        }
    }
}