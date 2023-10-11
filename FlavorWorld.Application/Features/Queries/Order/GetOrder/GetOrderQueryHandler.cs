using AutoMapper;
using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Application.Features.Query.Orders.GetProduct;
using FlavorWorld.Domain.Aggregates.Order.ValueObjects;
using FlavorWorld.Domain.Aggregates.OrderAggregate;
using MediatR;

namespace FlavorWorld.Application.Features.Query.Products.GetOrder;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Order>
{
    private readonly IOrderReadRepository<Order, OrderId> _orderReadRepository;
    private readonly IMapper _mapper;

    public GetOrderQueryHandler(IOrderReadRepository<Order, OrderId> orderReadRepository, IMapper mapper)
    {
        _orderReadRepository = orderReadRepository;
        _mapper = mapper;
    }

    public async Task<Order> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderReadRepository.GetAsync(p => p.Id == OrderId.Create(request.id));
        if (order is not null)
            return order;
        return default;
    }
}