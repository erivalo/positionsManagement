using Management.Service.Dtos;
using Management.Service.Filters;
using Management.Service.Infrastructure;
using Management.Service.Infrastructure.EventBus.Abstractions;
using Management.Service.IntegrationEvents;
using Management.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Management.Service.Endpoints;
public static class PositionApiEndpoints
{
  public static void RegisterEndpoints(this IEndpointRouteBuilder routeBuilder)
  {
    routeBuilder.MapPost("/api/positions", CreatePosition).AddEndpointFilter<ValidationFilter>();

    routeBuilder.MapPut("/api/positions/{positionId}", async Task<IResult> ([FromServices] IPositionRepository positionRepository, int positionId, UpdatePositionRequest request) =>
    {
      var positionFound = await positionRepository.GetById(positionId, true);
      if (positionFound is null)
      {
        return TypedResults.NotFound();
      }
      positionFound.Title = request.Title;
      positionFound.PositionNumber = request.PositionNumber;
      positionFound.PositionStatusId = request.StatusId;
      positionFound.RecruiterId = request.RecruiterId;
      positionFound.Budget = request.Budget;
      positionFound.DepartmentId = request.DepartmentId;

      await positionRepository.UpdatePosition(positionFound);

      return TypedResults.NoContent();
    });

    routeBuilder.MapGet("/api/positions/{positionId}", async Task<IResult> ([FromServices] IPositionRepository positionRepository, int positionId) =>
    {
      var position = await positionRepository.GetById(positionId, false);

      return position is null
        ? TypedResults.NotFound("Position Not Found")
        : TypedResults.Ok(new GetPositionResponse(
          position.Id,
          position.Title,
          position.Budget,
          position.RecruiterId,
          position.DepartmentId,
          position.PositionStatusId,
          position.PositionNumber));
    });

    routeBuilder.MapGet("/api/positions", async Task<IResult> ([FromServices] IPositionRepository positionRepository) =>
    {
      var positions = await positionRepository.GetPositions(false);

      return positions is null
        ? TypedResults.NotFound("Position Not Found")
        : TypedResults.Ok(positions);
    });

    routeBuilder.MapDelete("/api/positions/{positionId}", async Task<IResult> ([FromServices] IPositionRepository positionRepository, int positionId) =>
    {
      var positionFound = await positionRepository.GetById(positionId, true);
      if (positionFound is null)
      {
        return TypedResults.NotFound();
      }

      await positionRepository.DeletePosition(positionFound);

      return TypedResults.NoContent();
    });
  }

  internal static async Task<IResult> CreatePosition
  (
    [FromServices] IEventBus eventBus,
    [FromServices] IPositionRepository positionRepository,
    CreatePositionRequest request
  )
  {
    var position = new Position
    {
      Title = request.Title,
      PositionNumber = request.PositionNumber,
      PositionStatusId = 1,
      RecruiterId = request.RecruiterId,
      Budget = request.Budget,
      DepartmentId = request.DepartmentId,
    };

    await positionRepository.CreatePosition(position);

    eventBus.PublishAsync(new PositionCreatedEvent(position.Id.ToString()));

    return TypedResults.Created(position.Id.ToString());
  }
}