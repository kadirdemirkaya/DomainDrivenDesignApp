using FlavorWorld.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlavorWorld.Api.Filters;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // if (!context.ModelState.IsValid)
        // {
        //     var errors = context.ModelState.Where(x => x.Value.Errors.Any())
        //     .ToDictionary(e => e.Key, e => e.Value.Errors.Select(e => e.ErrorMessage))
        //     .ToArray();

        //     context.Result = new BadRequestObjectResult(errors);
        //     return;
        // }

        if (!context.ModelState.IsValid)
        {
            var errorsModelState = context.ModelState.Where(x => x.Value.Errors.Count() > 0)
                    .ToDictionary(e => e.Key, e => e.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

            var errorResponse = new ErrorResponse();
            foreach (var error in errorsModelState)
            {
                foreach (var e in error.Value)
                {
                    var errorModel = new ErrorModel
                    {
                        FieldName = error.Key,
                        Message = e
                    };
                    errorResponse.Errors.Add(errorModel);
                }
            }
            context.Result = new BadRequestObjectResult(errorResponse);
            return;
        }
        await next();
    }
}