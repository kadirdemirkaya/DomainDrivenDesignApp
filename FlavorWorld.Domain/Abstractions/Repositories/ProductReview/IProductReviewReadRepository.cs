using FlavorWorld.Abstractions.BaseTypes;
using FlavorWorld.Domain.Abstractions.Common;
using FlavorWorld.Domain.BaseTypes;

namespace FlavorWorld.Abstractions.Repository.ProductReview;

public interface IProductReviewReadRepository<T, TId> : IReadReposiyory<T, TId>
    where T : Entity<TId>
    where TId : ValueObject
{

}

