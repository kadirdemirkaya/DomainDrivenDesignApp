using FluentValidation;

namespace FlavorWorld.Application.Features.Queries.Authentication.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email).NotNull().NotEmpty().WithErrorCode("Email is not empty !");
        RuleFor(x => x.Password).NotNull().NotEmpty().WithErrorCode("Password is not empty !");
    }
}