using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Domain.Abstractions.Common;
using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Infrastructure.Persistence.Data;
using FlavorWorld.Infrastructure.Persistence.Repositories.Common;

namespace FlavorWorld.Infrastructure.Repositories;

public class ProductReadRepository : ReadRepository<Product, ProductId>, IProductReadRepository<Product, ProductId>
{
    public ProductReadRepository(FlavorWorldDbContext context) : base(context)
    {
    }
}

