using AutoMapper;
using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Domain.Aggregates.Order.ValueObjects;
using FlavorWorld.Domain.Aggregates.OrderAggregate;
using FlavorWorld.Domain.Aggregates.OrderAggregate.Events;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using MediatR;

namespace FlavorWorld.Application.Features.Commands.Orders.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
{
    private readonly IOrderWriteRepository<Order, OrderId> _orderWriteRepository;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IOrderWriteRepository<Order, OrderId> orderWriteRepository, IMapper mapper)
    {
        _orderWriteRepository = orderWriteRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Order.Create(request.orderId, request.Description, request.CreatedDate, UserId.Create(request.UserId));
        order.AddOrderDomainEvent(new OrderUpdatedEvent(order.Id.ToString()));
        bool result = _orderWriteRepository.UpdateAsync(order);
        int dbResult = await _orderWriteRepository.SaveChangesAsync();
        if (dbResult <= 0)
            result = false;
        return result;
    }
}