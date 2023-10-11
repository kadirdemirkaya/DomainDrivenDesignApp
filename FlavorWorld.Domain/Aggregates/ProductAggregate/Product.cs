using FlavorWorld.Domain.Abstractions.Common;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Entities;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Enums;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Events;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.BaseTypes;

namespace FlavorWorld.Domain.Aggregates.ProductAggregate;

public class Product : AggregateRoot<ProductId>
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public ProductStatus ProductStatus { get; private set; }
    public ProductDetail ProductDetail { get; private set; }

    private readonly List<ProductReview> _productReviews = new();
    public IReadOnlyCollection<ProductReview> ProductReview => _productReviews.AsReadOnly();


    public Product()
    {

    }

    public Product(ProductId id) : base(id)
    {
        Id = id;
    }

    public Product(ProductId id, string name, decimal price, DateTime createdDate, ProductStatus productStatus) : base(id)
    {
        Name = name;
        Price = price;
        CreatedDate = createdDate;
        ProductStatus = productStatus;
    }

    public static Product Create(Guid id)
    {
        var product = new Product(ProductId.Create(id));
        return product;
    }

    public static Product Create(string name, decimal price, DateTime createdDate, ProductStatus productStatus)
    {
        var product = new Product(ProductId.CreateUnique(), name, price, createdDate, productStatus);
        return product;
    }

    public static Product Create(Guid id, string name, decimal price, DateTime createdDate, ProductStatus productStatus)
    {
        var product = new Product(ProductId.Create(id), name, price, createdDate, productStatus);
        return product;
    }

    public void AddProductDomainEvent(IDomainEvent @event)
    {
        AddDomainEvent(@event);
    }

    public void AddProductDetail(ProductDetail productDetail)
    {
        ProductDetail = productDetail;
    }

    public void AddProductReview(ProductReview productReview)
    {
        _productReviews.Add(productReview);
    }

    public void RemoveProductReview(ProductReview productReview)
    {
        _productReviews.Remove(productReview);
    }

    public int CountProductReview()
    {
        return _productReviews.Count();
    }
}