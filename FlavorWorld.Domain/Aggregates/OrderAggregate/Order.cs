using FlavorWorld.Domain.Abstractions.Common;
using FlavorWorld.Domain.Aggregates.Order.ValueObjects;
using FlavorWorld.Domain.Aggregates.OrderAggregate.Entities;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.Aggregates.UserAggregate;
using FlavorWorld.Domain.BaseTypes;

namespace FlavorWorld.Domain.Aggregates.OrderAggregate;

public class Order : AggregateRoot<OrderId>
{
    public string Description { get; private set; }
    public DateTime CreatedDate { get; private set; }

    public UserId UserId { get; private set; }
    public User User { get; private set; }

    private readonly List<OrderItem> _orderItems = new();
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();


    public Order()
    {

    }

    public Order(OrderId id) : base(id)
    {
        Id = id;
    }
    public Order(OrderId id, string description, DateTime createdDate, UserId userId) : base(id)
    {
        Description = description;
        CreatedDate = createdDate;
        UserId = userId;
    }

    public static Order Create(Guid orderId)
    {
        return new(OrderId.Create(orderId));
    }

    public static Order Create(string description, DateTime createdDate, UserId userId)
    {
        return new(OrderId.CreateUnique(), description, createdDate, userId);
    }

    public static Order Create(Guid id, string description, DateTime createdDate, UserId userId)
    {
        return new(OrderId.Create(id), description, createdDate, userId);
    }

    public void AddOrderDomainEvent(IDomainEvent @event)
    {
        AddDomainEvent(@event);
    }


    public void AddOrderItem(OrderItem orderItem)
    {
        _orderItems.Add(orderItem);
    }

    public void RemoveOrderItem(OrderItem orderItem)
    {
        _orderItems.Remove(orderItem);
    }

    public int CountOrderItem()
    {
        return _orderItems.Count();
    }

    public void AddOrderDomainEvent(object deleteOrderEvent)
    {
        throw new NotImplementedException();
    }
}