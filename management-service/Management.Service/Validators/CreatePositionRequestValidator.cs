using FluentValidation;
using Management.Service.Dtos;

namespace Management.Service.Validators;
public class CreatePositionRequestValidator : AbstractValidator<CreatePositionRequest>
{
  public CreatePositionRequestValidator()
  {
    RuleFor(p => p.Budget)
      .GreaterThan(0)
      .WithMessage("Budget must be greater than 0");
    RuleFor(p => p.Title)
      .MinimumLength(3)
      .MaximumLength(100)
      .WithMessage("Title length must be between 3-100 characters");
  }
}