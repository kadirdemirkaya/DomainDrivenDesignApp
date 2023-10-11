using FlavorWorld.Application.Features.Commands.Authentication.Register;
using FluentValidation;

namespace FlavorWorld.Application.Features.Commands.Products.CreateProduct;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.CreatedDate).NotNull().NotEmpty().WithErrorCode("CreatedDate is not empty !");
        RuleFor(x => x.CustomerId).NotNull().NotEmpty().WithErrorCode("CustomerId is not empty !");
        RuleFor(x => x.Email).NotNull().NotEmpty().WithErrorCode("Email is not empty !");
        RuleFor(x => x.Password).NotNull().NotEmpty().WithErrorCode("Password is not empty !");
        RuleFor(x => x.UserName).NotNull().NotEmpty().WithErrorCode("UserName is not empty !");
        RuleFor(x => x.UserStatus).NotNull().NotEmpty().WithErrorCode("UserStatus is not empty !");
    }
}