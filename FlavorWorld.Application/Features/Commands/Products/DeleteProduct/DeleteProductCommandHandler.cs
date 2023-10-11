using AutoMapper;
using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Application.Features.Commands.Products.CreateProduct;
using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Events;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using MediatR;

namespace FlavorWorld.Application.Features.Commands.Products.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductWriteRepository<Product, ProductId> _productWriteRepository;
    private readonly IProductReadRepository<Product, ProductId> _productReadRepository;
    private readonly IMapper _mapper;

    public DeleteProductCommandHandler(IProductWriteRepository<Product, ProductId> productWriteRepository, IMapper mapper, IProductReadRepository<Product, ProductId> productReadRepository)
    {
        _productWriteRepository = productWriteRepository;
        _mapper = mapper;
        _productReadRepository = productReadRepository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        Product? product = await _productReadRepository.GetAsync(p => p.Id == ProductId.Create(request.id));
        product.AddProductDomainEvent(new ProductDeletedEvent(request.id));
        bool result = _productWriteRepository.Delete(Product.Create(request.id));
        int dbResult = await _productWriteRepository.SaveChangesAsync();
        if (dbResult < 0)
            result = false;
        return result;
    }
}