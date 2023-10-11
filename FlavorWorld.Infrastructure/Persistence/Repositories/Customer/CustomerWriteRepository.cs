using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Domain.Aggregates.CustomerAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Infrastructure.Persistence.Data;
using FlavorWorld.Infrastructure.Persistence.Repositories.Common;

namespace FlavorWorld.Infrastructure.Repositories;

public class CustomerWriteRepository : WriteRepositoy<Customer, CustomerId>, ICustomerWriteRepository<Customer, CustomerId>
{
    public CustomerWriteRepository(FlavorWorldDbContext context) : base(context)
    {
    }
}