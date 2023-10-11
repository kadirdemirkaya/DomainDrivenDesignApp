using System.Drawing;
using FlavorWorld.Application.Common.Behaviors;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;

namespace FlavorWorld.Api.Registrations;

public static class FluentValidationSettingRegistration
{
    public static IServiceCollection FluentValidationRegistration(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation(opt =>
        {
            opt.DisableDataAnnotationsValidation = true;
        }).AddValidatorsFromAssembly(AssemblyReference.Assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}