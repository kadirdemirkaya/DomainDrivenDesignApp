using FlavorWorld.Domain.Abstractions.Common;

namespace FlavorWorld.Domain.Aggregates.ProductAggregate.Events;

public record ProductUpdatedEvent(string ProductName) : IDomainEvent;