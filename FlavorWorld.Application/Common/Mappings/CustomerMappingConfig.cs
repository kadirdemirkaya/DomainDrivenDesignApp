using AutoMapper;
using FlavorWorld.Application.Features.Commands.Products.CreateCustomer;
using FlavorWorld.Application.Features.Commands.Products.UpdateCustomer;
using FlavorWorld.Contracts.Models.Customers;

namespace FlavorWorld.Application.Common.Mappings;

public class CustomerMappingConfig : Profile
{
    public CustomerMappingConfig()
    {
        CreateMap<CreateCustomerCommandDto, CreateCustomerCommand>().ReverseMap();

        CreateMap<UpdateCustomerCommandDto, UpdateCustomerCommand>().ReverseMap();
    }
}