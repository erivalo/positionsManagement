using FluentValidation;
using Management.Service.Dtos;

namespace Management.Service.Filters;
internal class ValidationFilter : IEndpointFilter
{
  private readonly IValidator<CreatePositionRequest> _validator;
  public ValidationFilter(IValidator<CreatePositionRequest> validator)
  {
    _validator = validator;
  }
  public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
  {
    var createPositionRequest = context.Arguments
      .FirstOrDefault(a => a.GetType() == typeof(CreatePositionRequest)) as CreatePositionRequest;
    var result = await _validator.ValidateAsync(createPositionRequest!);
    if (!result.IsValid) return Results.Json(result.Errors, statusCode: 400);

    return await next(context);
  }
}