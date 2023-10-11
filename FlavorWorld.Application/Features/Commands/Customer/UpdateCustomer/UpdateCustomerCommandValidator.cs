using FlavorWorld.Application.Features.Commands.Products.UpdateCustomer;
using FluentValidation;

namespace FlavorWorld.Application.Features.Commands.Products.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.id).NotNull().NotEmpty().WithErrorCode("Id is not empty !");
        RuleFor(x => x.Address).NotNull().NotEmpty().WithErrorCode("Address is not empty !");
        RuleFor(x => x.CreatedDate).NotNull().NotEmpty().WithErrorCode("CreatedDate is not empty !");
        RuleFor(x => x.FirstName).NotNull().NotEmpty().WithErrorCode("FirstName is not empty !");
        RuleFor(x => x.Gender).NotNull().NotEmpty().WithErrorCode("Gender is not empty !");
        RuleFor(x => x.LastName).NotNull().NotEmpty().WithErrorCode("LastName is not empty !");
        RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().WithErrorCode("PhoneNumber is not empty !");
        RuleFor(x => x.UserId).NotNull().NotEmpty().WithErrorCode("UserId is not empty !");
    }
}