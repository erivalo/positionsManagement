using Management.Service.Models;

namespace Management.Service.Infrastructure;
internal interface IPositionStore
{
  Task CreatePosition(Position position);
  Task<Position> GetById(int positionId);
}