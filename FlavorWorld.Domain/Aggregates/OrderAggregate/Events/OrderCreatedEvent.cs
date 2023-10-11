using FlavorWorld.Domain.Abstractions.Common;

namespace FlavorWorld.Domain.Aggregates.OrderAggregate.Events;

public record OrderCreatedEvent(string orderId) : IDomainEvent;