using FlavorWorld.Domain.Aggregates.OrderAggregate;
using FlavorWorld.Domain.Aggregates.OrderAggregate.Entities;

namespace FlavorWorld.Domain.Services;

public interface IOrderService
{
    Task<bool> CreateOrderWithOrderItemAsync(Order order);
}