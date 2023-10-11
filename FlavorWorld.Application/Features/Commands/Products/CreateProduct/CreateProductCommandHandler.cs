using AutoMapper;
using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Entities;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Events;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using MediatR;

namespace FlavorWorld.Application.Features.Commands.Products.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
{
    private readonly IProductWriteRepository<Product, ProductId> _productWriteRepository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductWriteRepository<Product, ProductId> productWriteRepository, IMapper mapper)
    {
        _productWriteRepository = productWriteRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.Create(request.Name, request.Price, request.CreatedDate, request.ProductStatus);
        product.AddProductDomainEvent(new ProductCreatedEvent(product.Name));
        product.AddProductDetail(request.ProductDetail);

        foreach (var productReview in request.ProductReviewsCommand)
        {
            product.AddProductReview(ProductReview.Create(product.Id, productReview.Stars, productReview.CreatedDate, product.Name));
        }

        bool result = await _productWriteRepository.CreateAsync(product);
        int dbResult = await _productWriteRepository.SaveChangesAsync();
        if (dbResult <= 0)
            result = false;
        return result;
    }
}