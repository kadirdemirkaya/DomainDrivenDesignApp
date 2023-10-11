using FlavorWorld.Abstractions.Repository;
using FlavorWorld.Domain.Enumerations;
using FlavorWorld.Infrastructure.Persistence.Data;
using FlavorWorld.Infrastructure.Persistence.Repositories.Common;

namespace FlavorWorld.Infrastructure.Repositories;

public class RoleWriteRepository : WriteRepositoy<Role>, IRoleWriteRepository
{
    public RoleWriteRepository(FlavorWorldDbContext context) : base(context)
    {
    }
}