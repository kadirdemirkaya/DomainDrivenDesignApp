using AutoMapper;
using FlavorWorld.Application.Features.Commands.Authentication.Register;
using FlavorWorld.Application.Features.Queries.Authentication.Login;
using FlavorWorld.Contracts.Dtos.Authentication;

public class AuthenticationMappingConfig : Profile
{
    public AuthenticationMappingConfig()
    {
        CreateMap<LoginCommand, LoginCommandDto>().ReverseMap();

        CreateMap<RegisterCommand, RegisterCommandDto>().ReverseMap();

        CreateMap<RoleCommand, RoleCommandDto>().ReverseMap();
    }
}