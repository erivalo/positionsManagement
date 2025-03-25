using Moq;
using Management.Service.Infrastructure;
using Management.Service.Models;
using Management.Service.Endpoints;
using Management.Service.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Management.Tests.Endpoints;
public class PositionApiEndpointsTests
{
  private readonly Mock<IPositionRepository> _positionRepository;

  public PositionApiEndpointsTests()
  {
    _positionRepository = new Mock<IPositionRepository>();
  }

  [Fact]
  public async Task GivenExistingPosition_WhenCallingGetPositionById_ThenReturnsPistion()
  {
    const int positionId = 1;
    var createPositionRequest = new CreatePositionRequest
    {
      PositionNumber = 1,
      Budget = 3500,
      Title = "Junior Software Engineer",
      DepartmentId = 1,
      RecruiterId = 1,
    };
    var position = new Position
    {
      Id = positionId,
      PositionStatusId = 1,
      DepartmentId = 1,
      RecruiterId = 1,
    };

    _positionRepository
      .Setup(repository => repository.GetById(positionId, false))
      .ReturnsAsync(position);

    var result = await PositionApiEndpoints.CreatePosition(_positionRepository.Object, createPositionRequest);

    Assert.NotNull(result);
    var createdResult = (Created)result;
    Assert.NotNull(createdResult);
  }
}