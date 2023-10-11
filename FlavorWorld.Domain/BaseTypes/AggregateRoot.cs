using System.Collections;
using FlavorWorld.Abstractions.BaseTypes;
using FlavorWorld.Domain.Abstractions.Common;

namespace FlavorWorld.Domain.BaseTypes;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
    where TId : notnull
{
    public AggregateRoot()
    {

    }
    protected AggregateRoot(TId id) : base(id)
    {
    }
}