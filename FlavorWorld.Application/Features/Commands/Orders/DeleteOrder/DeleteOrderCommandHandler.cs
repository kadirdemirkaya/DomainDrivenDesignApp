using AutoMapper;
using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Application.Features.Commands.Orders.CreateOrder;
using FlavorWorld.Application.Features.Commands.Orders.DeleteOrder;
using FlavorWorld.Domain.Aggregates.Order.ValueObjects;
using FlavorWorld.Domain.Aggregates.OrderAggregate;
using FlavorWorld.Domain.Aggregates.OrderAggregate.Events;
using MediatR;

namespace FlavorWorld.Application.Features.Commands.Products.DeleteOrder;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly IOrderWriteRepository<Order, OrderId> _orderWriteRepository;
    private readonly IOrderReadRepository<Order, OrderId> _orderReadRepository;
    private readonly IMapper _mapper;

    public DeleteOrderCommandHandler(IOrderWriteRepository<Order, OrderId> orderWriteRepository, IOrderReadRepository<Order, OrderId> orderReadRepository, IMapper mapper)
    {
        _orderWriteRepository = orderWriteRepository;
        _orderReadRepository = orderReadRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        Order? order = await _orderReadRepository.GetAsync(o => o.Id == OrderId.Create(request.id));
        order.AddOrderDomainEvent(new OrderDeletedEvent(order.Id.ToString()));
        bool result = _orderWriteRepository.Delete(Order.Create(request.id));
        int dbResult = await _orderWriteRepository.SaveChangesAsync();
        if (dbResult <= 0)
            result = false;
        return result;
    }
}