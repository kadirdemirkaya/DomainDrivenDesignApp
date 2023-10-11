using FluentValidation;

namespace FlavorWorld.Application.Features.Commands.Products.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().WithErrorCode("Id is not empty !");
        RuleFor(x => x.CreatedDate).NotNull().NotEmpty().WithErrorCode("CreatedDate is not empty !");
        RuleFor(x => x.Name).NotNull().NotEmpty().WithErrorCode("Name is not empty !");
        RuleFor(x => x.Price).NotNull().NotEmpty().WithErrorCode("Price is not empty !");
        RuleFor(x => x.ProductDetail).NotNull().NotEmpty().WithErrorCode("ProductDetail is not empty !");
        RuleFor(x => x.ProductStatus).NotNull().NotEmpty().WithErrorCode("ProductStatus is not empty !");
    }
}