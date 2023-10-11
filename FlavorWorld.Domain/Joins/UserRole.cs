using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.Enumerations;

namespace FlavorWorld.Domain.Joins;

public class UserRole
{
    public UserId UserId { get; private set; }

    public Guid RoleId { get; private set; }
    public Role Role { get; set; }

    public UserRole(UserId userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }

    public static UserRole Create(UserId UserId, Guid RoleId)
    {
        return new(UserId, RoleId);
    }
}