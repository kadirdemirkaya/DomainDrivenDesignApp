using FlavorWorld.Contracts.Models.Products;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FluentValidation;

namespace FlavorWorld.Api.Common.Validators;

public class ProductDetailValidator : AbstractValidator<ProductDetail>
{
    public ProductDetailValidator()
    {
        RuleFor(x => x.Color).NotNull().NotEmpty().WithErrorCode("Color is not empty !");
        RuleFor(x => x.Description).NotNull().NotEmpty().WithErrorCode("Description is not empty !");
        RuleFor(x => x.Manufacturer).NotNull().NotEmpty().WithErrorCode("Manufacturer is not empty !");
        RuleFor(x => x.Model).NotNull().NotEmpty().WithErrorCode("Model is not empty !");
        RuleFor(x => x.StockQuantity).NotNull().NotEmpty().WithErrorCode("StockQuantity is not empty !");
        RuleFor(x => x.WeightInGrams).NotNull().NotEmpty().WithErrorCode("WeightInGrams is not empty !");
    }
}