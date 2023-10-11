using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.Aggregates.UserAggregate;
using FlavorWorld.Infrastructure.Persistence.Data;
using FlavorWorld.Infrastructure.Persistence.Repositories.Common;

namespace FlavorWorld.Infrastructure.Repositories;

public class UserWriteRepository : WriteRepositoy<User, UserId>, IUserWriteRepository<User, UserId>
{
    public UserWriteRepository(FlavorWorldDbContext context) : base(context)
    {
    }
}