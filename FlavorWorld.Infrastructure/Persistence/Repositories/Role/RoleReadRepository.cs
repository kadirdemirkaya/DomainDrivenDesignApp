using FlavorWorld.Abstractions.Repository;
using FlavorWorld.Domain.Enumerations;
using FlavorWorld.Infrastructure.Persistence.Data;
using FlavorWorld.Infrastructure.Persistence.Repositories.Common;

namespace FlavorWorld.Infrastructure.Repositories;

public class RoleReadRepository : ReadRepository<Role>, IRoleReadRepository
{
    public RoleReadRepository(FlavorWorldDbContext context) : base(context)
    {
    }
}

