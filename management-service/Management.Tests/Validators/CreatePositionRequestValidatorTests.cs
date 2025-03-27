using FluentValidation.TestHelper;
using Management.Service.Dtos;
using Management.Service.Validators;

namespace Management.Tests.Validators;
public class CreatePositionRequestValidatorTests
{
  [Fact]
  public async Task GivenValidPosition_WhenCallingValidate_ThenReturnsNoValidationErrors()
  {
    var validator = new CreatePositionRequestValidator();
    var createPositionRequest = new CreatePositionRequest
    {
      Title = "Cloud Engineer",
      Budget = 4500,
      DepartmentId = 1,
      PositionNumber = 1,
      RecruiterId = 1,
    };

    var validationResults = await validator.TestValidateAsync(createPositionRequest);

    validationResults.ShouldNotHaveAnyValidationErrors();
  }

  [Fact]
  public async Task GivenInValidPositionBudget_WhenCallingValidate_ThenReturnsBudgetValidationErrors()
  {
    var validator = new CreatePositionRequestValidator();
    var createPositionRequest = new CreatePositionRequest
    {
      Title = "Cloud Engineer",
      Budget = -4500,
      DepartmentId = 1,
      PositionNumber = 1,
      RecruiterId = 1,
    };

    var validationResults = await validator.TestValidateAsync(createPositionRequest);

    validationResults.ShouldHaveValidationErrorFor(p => p.Budget);
  }
}