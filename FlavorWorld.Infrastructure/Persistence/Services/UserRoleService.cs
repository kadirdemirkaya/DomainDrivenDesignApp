using FlavorWorld.Domain.Abstractions.Common;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.Enumerations;
using FlavorWorld.Domain.Joins;
using FlavorWorld.Domain.Services;
using FlavorWorld.Infrastructure.Persistence.Data;

namespace FlavorWorld.Infrastructure.Persistence.Services;

public class UserRoleService : IUserRoleService
{
    private readonly FlavorWorldDbContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public UserRoleService(IUnitOfWork unitOfWork, FlavorWorldDbContext dbContext)
    {
        _unitOfWork = unitOfWork;
        _dbContext = dbContext;
    }

    public async Task<bool> CreateUserRole(UserId userId, List<Guid> RoleIds)
    {
        foreach (var roleId in RoleIds)
        {
            await _dbContext.Set<UserRole>().AddAsync(UserRole.Create(userId, roleId));
        }
        var dbResult = await _dbContext.SaveChangesAsync();
        return dbResult > 0 ? true : false;
    }
}