using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Domain.Aggregates.Order.ValueObjects;
using FlavorWorld.Domain.Aggregates.OrderAggregate;
using FlavorWorld.Domain.Aggregates.OrderAggregate.Entities;
using FlavorWorld.Domain.Aggregates.OrderAggregate.Events;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.Services;
using MediatR;

namespace FlavorWorld.Application.Features.Commands.Orders.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
{
    private readonly IOrderWriteRepository<Order, OrderId> _orderWriteRepository;
    private readonly IOrderService _orderService;

    public CreateOrderCommandHandler(IOrderWriteRepository<Order, OrderId> orderWriteRepository, IOrderService orderService)
    {
        _orderWriteRepository = orderWriteRepository;
        _orderService = orderService;
    }

    public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // Order? order = Order.Create(request.Description, request.CreatedDate, UserId.Create(request.UserId));
        // order.AddOrderDomainEvent(new OrderCreatedEvent(order.Id.ToString()));
        // foreach (var orderItem in request.OrderItemCommand)
        //     order.AddOrderItem(OrderItem.Create(orderItem.Quantity, orderItem.CreateDate, OrderId.Create(orderItem.OrderId), ProductId.Create(orderItem.ProductId)));
        // bool result = await _orderWriteRepository.CreateAsync(order);
        // int dbResult = await _orderWriteRepository.SaveChangesAsync();
        // if (dbResult <= 0)
        //     result = false;
        // return result;

        Order? order = Order.Create(request.Description, request.CreatedDate, UserId.Create(request.UserId));
        order.AddOrderDomainEvent(new OrderCreatedEvent(order.Id.ToString()!));
        foreach (var orderItem in request.OrderItemCommand)
            order.AddOrderItem(OrderItem.Create(orderItem.Quantity, orderItem.CreateDate, OrderId.Create(orderItem.OrderId), ProductId.Create(orderItem.ProductId)));
        bool response = await _orderService.CreateOrderWithOrderItemAsync(order);
        return response;
    }
}