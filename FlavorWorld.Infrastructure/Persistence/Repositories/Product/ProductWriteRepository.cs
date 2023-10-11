using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Infrastructure.Persistence.Data;
using FlavorWorld.Infrastructure.Persistence.Repositories.Common;

namespace FlavorWorld.Infrastructure.Repositories;

public class ProductWriteRepository : WriteRepositoy<Product, ProductId>, IProductWriteRepository<Product, ProductId>
{
    public ProductWriteRepository(FlavorWorldDbContext context) : base(context)
    {
    }
}