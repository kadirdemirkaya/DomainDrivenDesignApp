using FlavorWorld.Abstractions.BaseTypes;
using FlavorWorld.Domain.Aggregates.Order.ValueObjects;
using FlavorWorld.Domain.Aggregates.OrderAggregate.ValueObjects;
using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;

namespace FlavorWorld.Domain.Aggregates.OrderAggregate.Entities;

public sealed class OrderItem : Entity<OrderItemId>
{
    public int Quantity { get; private set; }
    public DateTime CreateDate { get; private set; }

    public OrderId OrderId { get; private set; }

    public ProductId ProductId { get; private set; }
    public Product Product { get; private set; }

    public OrderItem()
    {

    }

    public OrderItem(OrderItemId Id, int quantity, DateTime createdDate, OrderId orderId, ProductId productId) : base(Id)
    {
        Quantity = quantity;
        CreateDate = createdDate;
        OrderId = orderId;
        ProductId = productId;
    }

    public static OrderItem Create(int quantity, DateTime createdDate, OrderId orderId, ProductId productId)
    {
        return new(OrderItemId.CreateUnique(), quantity, createdDate, orderId, productId);
    }

}