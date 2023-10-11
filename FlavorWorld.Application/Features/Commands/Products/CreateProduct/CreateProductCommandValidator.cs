using FluentValidation;

namespace FlavorWorld.Application.Features.Commands.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode("Name is not empty !");
        RuleFor(x => x.Price).NotNull().NotEmpty().WithErrorCode("Price is not empty !");
        RuleFor(x => x.ProductStatus).NotEmpty().WithErrorCode("ProductStatus is not empty !");

        RuleFor(x => x.ProductDetail.Color).NotNull().NotEmpty().WithErrorCode("Color is not empty !");
        RuleFor(x => x.ProductDetail.Description).NotNull().NotEmpty().WithErrorCode("Description is not empty !");
        RuleFor(x => x.ProductDetail.Manufacturer).NotNull().NotEmpty().WithErrorCode("Manufacturer is not empty !");
        RuleFor(x => x.ProductDetail.Model).NotNull().NotEmpty().WithErrorCode("Model is not empty !");
        RuleFor(x => x.ProductDetail.StockQuantity).NotNull().NotEmpty().WithErrorCode("StockQuantity is not empty !");
        RuleFor(x => x.ProductDetail.WeightInGrams).NotNull().NotEmpty().WithErrorCode("WeightInGrams is not empty !");

        RuleForEach(x => x.ProductReviewsCommand).NotNull().NotEmpty().WithErrorCode("ProductReviews is not empty !");
    }
}