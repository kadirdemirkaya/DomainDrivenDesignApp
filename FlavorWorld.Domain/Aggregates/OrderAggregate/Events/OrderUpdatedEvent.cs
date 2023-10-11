using FlavorWorld.Domain.Abstractions.Common;

namespace FlavorWorld.Domain.Aggregates.OrderAggregate.Events;

public record OrderUpdatedEvent(string orderId) : IDomainEvent;