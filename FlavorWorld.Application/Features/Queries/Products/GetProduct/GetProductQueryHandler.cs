using AutoMapper;
using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using MediatR;

namespace FlavorWorld.Application.Features.Query.Products.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
{
    private readonly IProductReadRepository<Product, ProductId> _productReadRepository;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IProductReadRepository<Product, ProductId> productReadRepository, IMapper mapper)
    {
        _productReadRepository = productReadRepository;
        _mapper = mapper;
    }

    public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productReadRepository.GetAsync(p => p.Id == ProductId.Create(request.id));
        if (product is not null)
            return product;
        return default;
    }
}