using FlavorWorld.Domain.Aggregates.UserAggregate;
using FlavorWorld.Domain.BaseTypes;

namespace FlavorWorld.Domain.Enumerations;

public sealed class Role : Enumeration<Role>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<User> Users { get; set; }

    public Role()
    {

    }

    public Role(Guid id, string name) : base(id, name)
    {
    }
}