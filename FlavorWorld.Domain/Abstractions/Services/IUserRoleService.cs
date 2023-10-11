using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.Enumerations;

namespace FlavorWorld.Domain.Services;

public interface IUserRoleService
{
    public Task<bool> CreateUserRole(UserId userId, List<Guid> RoleIds);
}