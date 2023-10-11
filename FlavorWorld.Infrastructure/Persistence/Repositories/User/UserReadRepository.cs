using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.Aggregates.UserAggregate;
using FlavorWorld.Infrastructure.Persistence.Data;
using FlavorWorld.Infrastructure.Persistence.Repositories.Common;

namespace FlavorWorld.Infrastructure.Repositories;

public class UserReadRepository : ReadRepository<User, UserId>, IUserReadRepository<User, UserId>
{
    public UserReadRepository(FlavorWorldDbContext context) : base(context)
    {
    }
}

