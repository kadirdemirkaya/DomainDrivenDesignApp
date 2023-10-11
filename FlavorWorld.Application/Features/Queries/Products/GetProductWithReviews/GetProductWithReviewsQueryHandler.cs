using AutoMapper;
using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Abstractions.Repository.ProductReview;
using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Entities;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using MediatR;

namespace FlavorWorld.Application.Features.Query.Products.CreateProduct;

public class GetProductWithReviewsQueryHandler : IRequestHandler<GetProductWithReviewsQuery, List<ProductReview>>
{
    private readonly IProductReviewReadRepository<ProductReview, ProductReviewId> _productReviewReadRepository;
    private readonly IProductReadRepository<Product, ProductId> _productReadRepository;
    private readonly IMapper _mapper;

    public GetProductWithReviewsQueryHandler(IProductReviewReadRepository<ProductReview, ProductReviewId> productReviewReadRepository, IMapper mapper, IProductReadRepository<Product, ProductId> productReadRepository)
    {
        _productReviewReadRepository = productReviewReadRepository;
        _mapper = mapper;
        _productReadRepository = productReadRepository;
    }

    public async Task<List<ProductReview>> Handle(GetProductWithReviewsQuery request, CancellationToken cancellationToken)
    {
        var productReview = await _productReviewReadRepository.GetAllAsync(p => p.ProductId == ProductId.Create(request.id), true);
        if (productReview is not null)
            return productReview;
        return default;
    }
}