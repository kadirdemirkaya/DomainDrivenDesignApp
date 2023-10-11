using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Domain.Aggregates.CustomerAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Infrastructure.Persistence.Data;
using FlavorWorld.Infrastructure.Persistence.Repositories.Common;

namespace FlavorWorld.Infrastructure.Repositories;

public class CustomerReadRepository : ReadRepository<Customer, CustomerId>, ICustomerReadRepository<Customer, CustomerId>
{
    public CustomerReadRepository(FlavorWorldDbContext context) : base(context)
    {
    }
}

