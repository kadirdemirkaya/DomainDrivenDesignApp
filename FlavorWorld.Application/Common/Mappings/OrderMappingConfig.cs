using AutoMapper;
using FlavorWorld.Application.Features.Commands.Orders.CreateOrder;
using FlavorWorld.Application.Features.Commands.Orders.DeleteOrder;
using FlavorWorld.Application.Features.Commands.Products.UpdateProduct;
using FlavorWorld.Application.Features.Query.Orders.GetProduct;
using FlavorWorld.Contracts.Models.Orders;
using FlavorWorld.Contracts.Models.Products;
using FlavorWorld.Domain.Aggregates.OrderAggregate.Entities;
namespace FlavorWorld.Application.Common.Mappings;

public class OrderMappingConfig : Profile
{
    public OrderMappingConfig()
    {
        CreateMap<CreateOrderCommand, CreateOrderCommandDto>().ReverseMap()
            .ForMember(dest => dest.OrderItemCommand, opt => opt.MapFrom(src => src.OrderItemCommand));

        CreateMap<OrderItemCommand, OrderItemCommandDto>()
            .ReverseMap();

        CreateMap<OrderItem, OrderItemCommand>().ReverseMap();

        CreateMap<DeleteOrderCommandDto, DeleteOrderCommand>().ReverseMap();

        CreateMap<UpdateProductCommandDto, UpdateProductCommand>().ReverseMap();

        CreateMap<GetOrderQueryDto, GetOrderQuery>().ReverseMap();
    }
}