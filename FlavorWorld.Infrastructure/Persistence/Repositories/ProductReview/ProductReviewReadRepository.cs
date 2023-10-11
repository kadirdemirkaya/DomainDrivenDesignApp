using FlavorWorld.Abstractions.Repository.ProductReview;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Entities;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Infrastructure.Persistence.Data;
using FlavorWorld.Infrastructure.Persistence.Repositories.Common;

namespace FlavorWorld.Infrastructure.Repositories;

public class ProductReviewReadRepository : ReadRepository<ProductReview, ProductReviewId>, IProductReviewReadRepository<ProductReview, ProductReviewId>
{
    public ProductReviewReadRepository(FlavorWorldDbContext context) : base(context)
    {
    }
}

