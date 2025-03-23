using Management.Service.Dtos;
using Management.Service.Infrastructure;
using Management.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Management.Service.Endpoints;
public static class PositionApiEndpoints
{
  public static void RegisterEndpoints(this IEndpointRouteBuilder routeBuilder)
  {
    routeBuilder.MapPost("/api/positions", async Task<IResult> ([FromServices] IPositionStore positionStore, CreatePositionRequest request) =>
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

      await positionStore.CreatePosition(position);

      return TypedResults.Created(position.Id.ToString());
    });

    routeBuilder.MapGet("/api/positions/{positionId}", async Task<IResult> ([FromServices] IPositionStore positionStore, int positionId) =>
    {
      var position = await positionStore.GetById(positionId);

      return position is null
        ? TypedResults.NotFound("Position Not Found")
        : TypedResults.Ok(new GetPositionResponse(position.Id, position.Title, position.Budget, position.RecruiterId, position.DepartmentId));
    });
  }
}