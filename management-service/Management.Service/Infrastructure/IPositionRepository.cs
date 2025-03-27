using Management.Service.Models;

namespace Management.Service.Infrastructure;
internal interface IPositionRepository
{
  Task CreatePosition(Position position);
  Task UpdatePosition(Position position);
  Task DeletePosition(Position positionId);
  Task<Position> GetById(int positionId, bool trackChanges);
  Task<List<Position>> GetPositions(bool trackChanges);
}