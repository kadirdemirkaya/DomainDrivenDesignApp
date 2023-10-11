using FlavorWorld.Application.Features.Commands.Products.CreateProduct;
using FluentValidation;

namespace FlavorWorld.Application.Features.Commands.Products.DeleteProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.id).NotNull().NotEmpty().WithErrorCode("Id is not empty !");
    }
}