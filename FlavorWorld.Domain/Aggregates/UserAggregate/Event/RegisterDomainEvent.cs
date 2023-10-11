using FlavorWorld.Domain.Abstractions.Common;

namespace FlavorWorld.Domain.Aggregates.UserAggregate.Events;

public record RegisterDomainEvent(string Name) : IDomainEvent;