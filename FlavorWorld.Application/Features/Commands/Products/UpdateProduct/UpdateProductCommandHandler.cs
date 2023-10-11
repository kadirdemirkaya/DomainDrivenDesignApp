using AutoMapper;
using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Application.Features.Commands.Products.CreateProduct;
using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Events;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using MediatR;

namespace FlavorWorld.Application.Features.Commands.Products.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductWriteRepository<Product, ProductId> _productWriteRepository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductWriteRepository<Product, ProductId> productWriteRepository, IMapper mapper)
    {
        _productWriteRepository = productWriteRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.Create(request.Id, request.Name, request.Price, request.CreatedDate, request.ProductStatus);
        product.AddProductDomainEvent(new ProductUpdatedEvent(product.Name));
        product.AddProductDetail(request.ProductDetail);
        bool result = _productWriteRepository.UpdateAsync(product);
        int dbResult = await _productWriteRepository.SaveChangesAsync();
        if (dbResult < 0)
            result = false;
        return result;
    }
}